using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

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
			self.position + ( speed * Time.deltaTime * getInput () )
		);
		//Debug.Log ( self.position );
	}

	// Returns input normalized to the unit circle
	private Vector2 getInput(){	
		return (new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"))).normalized;
	}

	private Vector2 snapToPixels(Vector2 before){
		return (new Vector2( snap * Mathf.Round(before.x / snap), snap * Mathf.Round(before.y / snap)));
	}
}