using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;

	public Transform goal;
	public World world;

	private Rigidbody self;
	private float inputX;
	private float inputY;
	private Vector2 cumulativeMovement;

	void Start () {
		self = GetComponent<Rigidbody> ();
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
    }

    IEnumerator SpeedPowerUp()
    {
        speed *= 2;
        yield return new WaitForSeconds(20f);
        speed /= 2;
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
