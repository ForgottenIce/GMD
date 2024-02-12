using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FireworkController : MonoBehaviour
{
    [SerializeField]
    private float rocketSpeed = 8f;
    [SerializeField]
    private float rocketDuration = 2f;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        // Debug.Log("Start was called");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update was called");
        transform.Translate(Vector3.up * Time.deltaTime * rocketSpeed);

        if (Time.time >= spawnTime + rocketDuration) Destroy(gameObject);
    }
}
