using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;

	private Rigidbody self;
	private float inputX;
	private float inputY;
	private Vector2 cumulativeMovement;

	void Start () {
		self = GetComponent<Rigidbody> ();
	}

	void Update () {

	}

	void FixedUpdate(){
		self.MovePosition (
			self.position + ( speed * Time.deltaTime * getInput () )
		);
	}

	private Vector3 getInput(){
		return (new Vector3 (Input.GetAxisRaw ("Horizontal"),0, Input.GetAxisRaw ("Vertical"))).normalized;
	}
}
