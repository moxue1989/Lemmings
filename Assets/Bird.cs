using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	public Transform bird;
	public float offset;
	// Use this for initialization
	public virtual void Start () {
		bird = GetComponent<Transform>();
		offset = Random.value;
	}
	
	// Update is called once per frame
	public virtual void Update () {
				
		Vector3 position = bird.position;
		position.y += Mathf.Sin(Time.time * offset * Mathf.PI * 2 ) / 20;
		position.y += Mathf.Sin(Time.time * Mathf.PI * 4 ) / 50;
		bird.localPosition = position;
	}
}
