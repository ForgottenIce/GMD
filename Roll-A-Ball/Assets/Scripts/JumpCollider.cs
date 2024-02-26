using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{

    public bool canJump = false;

    private void OnTriggerStay(Collider other)
    {
        canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canJump = false;
    }

    void LateUpdate()
    {
        transform.position = transform.parent.position + new Vector3(0, -0.5f, 0);
    }
}
