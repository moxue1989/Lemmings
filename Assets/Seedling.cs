using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public Rigidbody rb;
    protected internal int force;

    // Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
    

    // Update is called once per frame
    void Update ()
    {
        force = 0;
        rb.AddForce(force,force,force);
    }
}
