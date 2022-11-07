//  (C) Niklas Köppl 2022
//  This code is licensed under Mozilla Public License 2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float accelerationSpeed = 10f;
    public float turningCoefficient = 0.2f;

    public Rigidbody rb;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    
    void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Vertical") * Vector3.right * accelerationSpeed);
        rb.AddTorque(Input.GetAxis("Horizontal") * Vector3.up * accelerationSpeed * turningCoefficient);
    }
}