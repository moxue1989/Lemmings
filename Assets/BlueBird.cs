using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : Bird {

	// Use this for initialization
	public override void Start () {
		base.Start();
		offset = Random.Range(1,5) * 0.1f;

	}
	
	// Update is called once per frame

}
