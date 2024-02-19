using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyInput : MonoBehaviour {

	void Update () {
		string input = Input.inputString;
		if(input != null && !"".Equals(input)) Debug.Log (input);
	}
}
