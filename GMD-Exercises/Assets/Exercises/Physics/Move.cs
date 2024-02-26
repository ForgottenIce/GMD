using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 0.1f;
    private string direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(4f, 0.5f, -4f);
        direction = "left";
    }

    void FixedUpdate()
    {
        float xVel = 0;
        float zVel = 0;
        switch (direction)
        {
            case "up":
                zVel = moveSpeed;
                break;
            case "right":
                xVel = moveSpeed;
                break;
            case "down":
                zVel = -moveSpeed;
                break;
            case "left":
                xVel = -moveSpeed;
                break;
        }
        rb.MovePosition(transform.position + new Vector3(xVel, 0, zVel));
        if (transform.position.x <= -4f && transform.position.z <= -4f) direction = "up";
        else if (transform.position.x <= -4f && transform.position.z >= 4f) direction = "right";
        else if (transform.position.x >= 4f && transform.position.z >= 4f) direction = "down";
        else if (transform.position.x >= 4f && transform.position.z <= -4f) direction = "left";


    }
}
