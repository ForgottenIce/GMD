using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateScript : MonoBehaviour {

	private bool canMove = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			canMove = true;
		}
		if (!canMove)
			return;

		transform.Translate (Vector3.right * 2f * Time.deltaTime);
	}
}
