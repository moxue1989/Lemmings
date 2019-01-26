using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class AgentMovement : MonoBehaviour {

	public float speed = 5.0f;
	public float snap=1.0f;

	private Rigidbody2D self;
	private float inputX;
	private float inputY;
	private Vector2 cumulativeMovement;

	// Use this for initialization
	void Start () {
		self = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Update is called at fixed intervals
	void FixedUpdate(){
		// * speed * Time.deltaTime
		self.MovePosition (
			self.position = ( generatePosition(speed) )
		);
		Debug.Log ( self.position );
	}

    private Vector2 generatePosition(float speed){
        return (new Vector2 (Mathf.Sin(speed * Time.time), 0)).normalized;
    }

}