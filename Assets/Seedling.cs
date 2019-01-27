using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public Rigidbody rb;
<<<<<<< HEAD
    protected internal int force;
    public GameObject timer;
=======
>>>>>>> 9d23f757f0201639df70b0a503c578020a7305fe

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(0,0,0);
	}
}
