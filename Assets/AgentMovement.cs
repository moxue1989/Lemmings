using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class AgentMovement : MonoBehaviour {

	public float speed = 5.0f;
	public Vector2 startingPosition;
	public float amplitude = 1f;

	private Rigidbody2D self;

	void Start () {
		self = GetComponent<Rigidbody2D> ();
	}

	void Update () {

	}

	void FixedUpdate(){
		self.MovePosition (
			self.position = ( generatePosition(speed) )
		);
		Debug.Log ( self.position );
	}

    private Vector2 generatePosition(float speed){
			  float sin = Mathf.Sin(speed * Time.time);
        return (new Vector2 (amplitude * sin + startingPosition.x, startingPosition.y));
    }

}
