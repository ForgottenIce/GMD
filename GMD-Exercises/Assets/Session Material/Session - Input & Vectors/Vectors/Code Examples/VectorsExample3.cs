using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorsExample3 : MonoBehaviour {

	[Range(0f, 1f)]
	public float lerp;

	public Transform t1, t2;
	
	void Update () {
		transform.position = Vector3.Lerp (t1.position, t2.position, lerp);
	}
}
