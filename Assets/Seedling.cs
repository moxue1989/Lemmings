using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public Rigidbody rb;
    protected internal int force;
    public GameObject timer;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(0,0,0);
	}
}
