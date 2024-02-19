using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyExample : MonoBehaviour {

	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Space is pressed");
		} 
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log ("Space is held down");
		} 
		if (Input.GetKeyUp (KeyCode.Space)) {
			Debug.Log ("Space is released");
		}

	}
}
