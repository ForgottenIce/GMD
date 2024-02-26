using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHitterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit)) {
				Debug.Log ("Something is in front of me");
				Debug.Log (" -> " + hit.collider.gameObject);
				Debug.Log ("Hit point: " + hit.point);
			}

			if (Physics.Raycast (transform.position, transform.right)) {
				Debug.Log ("Something is to my right");
				Debug.Log ("But this time I didn't care about info");
			}
		}
	}
}
