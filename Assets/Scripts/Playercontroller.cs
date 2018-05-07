using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Playercontroller : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource au;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public GameObject seeGong;
    public Transform shotspawn;
    public Transform seegongspawn;
    
    
    public float fireDelta;

    private float nextfire;
    private float nextseegong;
    private int sleft;
    public float seegongDelta;
    
    

    private void Start()
    {
        sleft = 3;
        rb = GetComponent<Rigidbody>();
        au = GetComponent<AudioSource>();
    }
    void Update()
    {

        
        if (Input.GetButton("Fire1") && Time.time > nextfire)
        {
            nextfire = Time.time + fireDelta;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);
            au.Play ();

        }
        if(Input.GetKeyDown(KeyCode.S) && Time.time > nextseegong && sleft > 0)
        {
            nextseegong = Time.time + seegongDelta;
            Instantiate(seeGong, seegongspawn.position, seegongspawn.rotation);
            sleft = sleft - 1;
        }
    }
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
   
}