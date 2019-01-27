using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;

<<<<<<< HEAD
    public Transform goal;
    public World world;

	private Rigidbody self;
=======
	private Transform self;
>>>>>>> efd18d83ead2ca4f894c9a1f29513eb5e58ba7ef
	private float inputX;
	private float inputY;
	private Vector2 cumulativeMovement;

	void Start () {
		self = GetComponent<Transform> ();
	}

	void Update ()
	{
	    Vector3 goalPosition = goal.position;

	    Vector3 selfPosition = self.transform.position;

	    Vector3 vector3 = goalPosition - selfPosition;

	    if (vector3.magnitude <= 1)
	    {
            world.endGame(true);
	    }
	}

	void FixedUpdate(){
		
			self.position += ( speed * Time.deltaTime * GetMovement () );
		
	}

	private Vector3 GetMovement(){
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		float up = horizontal + vertical == 0f ? 0 : 1;
		return (new Vector3 (Input.GetAxisRaw ("Horizontal"),up, Input.GetAxisRaw ("Vertical"))).normalized;
	}
}
