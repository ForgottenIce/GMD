using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBExampleScript : MonoBehaviour {

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	

	void Update () { // Update is called once per frame
		
	}

	void LateUpdate() { // called after Update

	}

	void FixedUpdate() { // called at a set interval
		rb.AddForce(Vector3.down * 30f); // gravity of 30, usually 9.82f
	}
}
