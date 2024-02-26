using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-4f, 4f);
        float z = Random.Range(-4f, 4f);
        transform.Translate(new Vector3(x, 0, z));
    }
}
