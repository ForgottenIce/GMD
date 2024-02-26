using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForces : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightControl)) {
			gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (10f, 0f, 0f));
		}

		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			gameObject.GetComponent<Rigidbody> ().AddTorque (Random.insideUnitSphere * 10f * Random.Range(-1, 1));
		}
	}
}
