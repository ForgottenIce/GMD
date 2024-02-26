using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorsExample2 : MonoBehaviour {
	
	void Start () {
		transform.position = Vector2.Lerp(new Vector2(-7f, 8f), new Vector2(7f, 4f), 0.5f);
	}
	
	void Update () {
		transform.eulerAngles = new Vector3 (45f, 0f, 0f);
	}
}
