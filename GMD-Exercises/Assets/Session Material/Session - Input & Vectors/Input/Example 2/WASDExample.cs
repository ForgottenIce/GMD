using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDExample : MonoBehaviour {

	void Update () {
		if (Input.GetKey (KeyCode.W) ) {
			transform.Translate (Vector3.forward * 5f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate ( -Vector3.forward * 5f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.up, -50f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up, 50f * Time.deltaTime);
		}
	}
}
