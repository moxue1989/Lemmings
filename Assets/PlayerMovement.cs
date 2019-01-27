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
			self.position + ( speed * Time.deltaTime * GetMovement () )
		);
	}

	private Vector3 GetMovement(){
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		float up = horizontal + vertical == 0f ? 0 : 1;
		return (new Vector3 (Input.GetAxisRaw ("Horizontal"),up, Input.GetAxisRaw ("Vertical"))).normalized;
	}
}
