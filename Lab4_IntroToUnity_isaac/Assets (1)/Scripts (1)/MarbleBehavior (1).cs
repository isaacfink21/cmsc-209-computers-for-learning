using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float rotateSpeed = 0.5f;
 
    private float fbInput;
    private float lrInput;

    private Rigidbody _rb;

    void Start()
    {
        //You'll need to add a rigidbody to the marble first
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Put code is for movement using the Sprite's native variables here
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
        this.transform.Translate(Vector3.forward * fbInput * Time.time);
        this.transform.Rotate(Vector3.up * lrInput * Time.time);
    }

    void FixedUpdate()
    {
        //Put code that moves the sprite using the RigidBody here

    }

}
