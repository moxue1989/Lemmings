using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShadowRendererer : MonoBehaviour {
	Renderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		renderer.receiveShadows = true;
		renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
