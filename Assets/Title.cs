using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {

	Transform title;
	// Use this for initialization
	void Start () {
		title = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = title.position + Vector3.one;
		title.position = position;
	}
}
