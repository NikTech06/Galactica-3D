using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform camera;

    [Range(0, 30)]
    [SerializeField] private float accelerateSpeed = 10f;
    [SerializeField] private float rotateSpeed = 3f;

    Quaternion rot;

    void Update()
    {
        //moving
        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(Vector3.back * accelerateSpeed * Time.deltaTime * 100);
        }

        if (Input.GetButton("Brake"))
        {
            rb.AddForce(Vector3.forward * accelerateSpeed * Time.deltaTime * 100);
        }

        //rotating
        Vector3 rotationAmount = camera.rotation - transform.rotation;
        rot.eulerAngles = rotationAmount;
        transform.rotation = rot;
    }
}

