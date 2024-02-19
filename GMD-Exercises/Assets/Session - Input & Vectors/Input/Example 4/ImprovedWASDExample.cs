using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedWASDExample : MonoBehaviour {

	void Update () {
		float vertical = Input.GetAxis ("Vertical");
		if (vertical != 0f ) {
			transform.Translate (vertical * Vector3.forward * 5f * Time.deltaTime);
		}

		float horizontal = Input.GetAxis ("Horizontal");
		if (horizontal != 0f) {
			transform.Rotate (Vector3.up, 50f * Time.deltaTime * horizontal);
		}

		if ( Input.GetButtonDown ("Jump") ) { // teleport
			transform.Translate (Vector3.forward * 3f);
		}
	}
}
