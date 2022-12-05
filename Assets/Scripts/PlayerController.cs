using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    [Range(0, 30)]
    public float speed = 10f;

    public float defaultAngularDrag = 0.05f;
    public float gravityZoneAngularDrag = 10f;

    void Update()
    {
        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime * 100);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.useGravity = true;
        rb.angularDrag = gravityZoneAngularDrag;
    }

    private void OnTriggerExit(Collider other)
    {
        rb.useGravity = false;
        rb.angularDrag = defaultAngularDrag;
    }
}
