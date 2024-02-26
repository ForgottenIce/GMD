using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereAttract : MonoBehaviour
{
    [SerializeField]
    private GameObject otherSphere;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 direction = otherSphere.transform.position - transform.position;
            rb.AddForce(direction);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().path);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == otherSphere)
        {
            Debug.Log("Collision!");
        }
    }
}
