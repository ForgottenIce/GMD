using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForcesBall : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightControl)) {
			gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (250f, 0f, 0f));
		}

		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			gameObject.GetComponent<Rigidbody> ().AddTorque (new Vector3 (25f, 0f, 0f));
		}
	}
}
