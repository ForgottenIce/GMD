using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{

	Rigidbody rb;

	// Use this for initialization
	void Start () {

		Vector3 vec = new Vector3 (1f, 2f, 0f);  // direction
		Vector3 point = new Vector3 (-1f, 0f, 2f);  // point

		Ray ray = new Ray (new Vector3 (0f, 1f, -1f), new Vector3 (0f, 2f, 1f));


		Vector2 v2 = new Vector2 (2f, 5f);

		Ray r2 = new Ray(new Vector2(3f, 2f), new Vector2(2f, 3f));
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody>().AddForce(new Vector3(500f, 0f, 0f));
		}
	}

	void Method() {
		rb.velocity = new Vector3 (1f, 0f, 3f);
	}

}
