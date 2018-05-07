using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seegong : MonoBehaviour
{
    public float tumble;
    
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    void Update()
    {
       
        transform.Rotate(Vector3.up, tumble * Time.deltaTime);
    }
}
