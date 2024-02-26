using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputExample : MonoBehaviour {

	void OnMouseDown() {
		Debug.Log ("Clicked");
	}

	void OnMouseOver() {
		Debug.Log ("Hover");
	}
}
