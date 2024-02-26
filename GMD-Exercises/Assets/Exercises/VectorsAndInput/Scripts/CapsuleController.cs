using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical != 0f)
        {
            transform.Translate(vertical * Vector3.forward * 5f * Time.deltaTime);
        }

        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0f)
        {
            transform.Translate(horizontal * Vector3.right * 5f * Time.deltaTime);
        }
    }
}
