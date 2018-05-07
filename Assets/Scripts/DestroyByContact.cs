using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject PlayerExplosion;
    public int ScoreValue;
    private Gamecontroller _gameController;

    private void Start()
    {
        ScoreValue = 10;
        var gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            _gameController = gameControllerObject.GetComponent<Gamecontroller>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }
        Instantiate(Explosion, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            _gameController.GameOver();
        }
        if (other.CompareTag("seegong"))
        {
            _gameController.AddScore(ScoreValue);
            Destroy(gameObject);
            
        }
        if (!other.CompareTag("seegong"))
        {
            _gameController.AddScore(ScoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
