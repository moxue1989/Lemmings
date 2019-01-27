using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;

	public Transform goal;
	public Transform timer;
	public World world;

	private Rigidbody self;
	public Collider Ground;
	private float inputX;
	private float inputY;
	private Vector2 cumulativeMovement;

	void Start () {
		self = GetComponent<Rigidbody> ();
		Debug.Log(transform.eulerAngles);
	}

	void Update ()
	{
		Vector3 playerPosition = transform.position;
	    playerPosition.y += 1;
		// timer.localPosition = playerPosition;
		timer.localEulerAngles = new Vector3(0,0,0);

		Vector3 goalPosition = goal.position;

	    Vector3 selfPosition = self.transform.position;

	    Vector3 vector3 = goalPosition - selfPosition;

	    if (vector3.magnitude <= 1)
	    {
            world.endGame(true);
	    }

	    if (selfPosition.y <= -1)
	    {
	        world.endGame(false);
        }

	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PowerUp")
        {
            collision.gameObject.SetActive(false);
            StartCoroutine(SpeedPowerUp());
        }
		if (collision.gameObject.name == "Ground")
		{
			self.velocity *= 0;
			transform.localEulerAngles = new Vector3(0,45,0);
		}

    }

    IEnumerator SpeedPowerUp()
    {
        speed *= 2;
        yield return new WaitForSeconds(20f);
        speed /= 2;
    }
    void FixedUpdate(){
		self.AddForce(new Vector3(0,0,0));
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out hit, 100.0f))
      {
        // Debug.Log("You selected the " + hit.transform.name);
		// var item = GameObject.CreatePrimitive(PrimitiveType.Cube);
		// item.transform.position = hit.point;
	  }

			// Debug.Log("Mouse 1 Clicked");
			Vector3 vectorForce = (hit.point - self.position);
			vectorForce.y += 5;
			vectorForce *= 70;
			if(self.velocity.magnitude < 0.1){
				self.AddForce(vectorForce);
			}
			// Debug.Log(self.velocity.magnitude);
		}
		// self.position += ( speed * Time.deltaTime * GetMovement () );
		
	}

	private Vector3 GetMovement(){
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		float up = horizontal + vertical == 0f ? 0 : 1;
		return (new Vector3 (Input.GetAxisRaw ("Horizontal"),up, Input.GetAxisRaw ("Vertical"))).normalized;
	}
}
