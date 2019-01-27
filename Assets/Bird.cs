using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	Transform bird;
	float offset;
	// Use this for initialization
	void Start () {
		bird = GetComponent<Transform>();
		offset = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
				
		Vector3 position = bird.position;
		position.y += Mathf.Sin(Time.time * offset * Mathf.PI * 2 ) / 20;
		position.y += Mathf.Sin(Time.time * Mathf.PI * 4 ) / 50;
		bird.localPosition = position;
	}
}
