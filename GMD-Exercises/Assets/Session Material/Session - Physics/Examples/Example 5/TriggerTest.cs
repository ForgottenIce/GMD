using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag.Equals("Sphere"))
			Debug.Log ("Ouch, " + col.gameObject.name + " hit me!");
	}

	void OnTriggerStay(Collider col) {
		if(col.gameObject.tag.Equals("Sphere"))
			Debug.Log ("Ew, " + col.gameObject.name + " is touching me!");
	}

	void OnTriggerExit(Collider col) {
		if(col.gameObject.tag.Equals("Sphere"))
			Debug.Log ("It's so lonely when you leave");
	}
}
