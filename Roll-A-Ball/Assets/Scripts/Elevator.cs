using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Rigidbody rb;
    private bool elevate = false;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = rb.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            elevate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            elevate = false;
        }
    }

    void FixedUpdate()
    {
        if (elevate && rb.position.y < startPos.y + 10)
        {
            rb.MovePosition(rb.position + new Vector3(0, 0.1f, 0));
        }
        if (!elevate && rb.position.y > startPos.y)
        {
            rb.MovePosition(rb.position + new Vector3(0, -0.1f, 0));
        }
    }
}
