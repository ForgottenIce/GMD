using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag.Equals("Sphere"))
			Debug.Log ("Ouch, " + col.gameObject.name + " hit me!");
	}

	void OnCollisionStay(Collision col) {
		if(col.gameObject.tag.Equals("Sphere"))
			Debug.Log ("Ew, " + col.gameObject.name + " is touching me!");
	}

	void OnCollisionExit(Collision col) {
		if(col.gameObject.tag.Equals("Sphere"))
			Debug.Log ("It's so lonely when you leave");
	}
}
