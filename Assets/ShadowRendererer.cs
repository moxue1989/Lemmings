using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowRendererer : MonoBehaviour {
	Renderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		renderer.receiveShadows = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
