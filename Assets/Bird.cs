using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
  Transform bird;
  public World world;
  bool found_goal;
  int[] primary_goal;
  int[] secondary_goal;
  int[] next_block;
  float jumpTime;
  float nextJump;
  Rigidbody self;
  public float offset;
  // Use this for initialization
  public virtual void Start()
  {
    // get primary goal
    // get secondary goal
    self = GetComponent<Rigidbody>();
    
    primary_goal = new int[] { GetRandomInt(), GetRandomInt() };
    secondary_goal = new int[] { GetRandomInt(), GetRandomInt() };
    jumpTime = 0;
    nextJump = Random.Range(20,60) / 10f;
    bird = transform;
    offset = Random.value;
  }

  int GetRandomInt() {
    return Mathf.FloorToInt(Random.Range(-16,16));
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "Ground")
    {
      transform.localEulerAngles = new Vector3(0, 45, 0);
    }
		if (collision.gameObject.name == "Player")
		{
      Debug.Log("LOSE HEALTH");
			world.endGame(false);
		}
  }
  // Update is called once per frame
  public virtual void Update()
  {
    jumpTime += Time.deltaTime;

    if(jumpTime > nextJump) {

      Vector3 position = bird.position;
      // Quaternion rotation = bird.rotation;
      jumpTime = 0;

      // position.y += Mathf.Sin(Time.time * offset * Mathf.PI * 2) / 20;
      // position.y += Mathf.Sin(Time.time * Mathf.PI * 4) / 50;
      
      // GameObject world = world;
      // var script = plane_object.GetComponent<Plane>();
      Transform birds = transform.parent;
      Transform world = birds.transform.parent;
      GameObject worldObject = world.gameObject;
      var script = worldObject.GetComponent<World>();

      int[] bird_uv = script.ReturnGridPosition(position.x, position.y);

      int next_goal_x = found_goal ? primary_goal[0] : secondary_goal[0];
      int next_goal_z = found_goal ? primary_goal[1] : secondary_goal[1];

      // Vector3 next_block = PathingController.get_instance().query_graph_to_vec3(bird_uv[0], bird_uv[1], next_goal_x + 15, next_goal_z + 15);
      Vector3 next_block = new Vector3(next_goal_x, 1, next_goal_z);
      //next_block *= 50f * Random.value;
      Vector3 bird_direction = new Vector3(GetRandomInt(), GetRandomInt(), GetRandomInt());
      // Debug.Log("Position =>" + bird_uv[0] + "," + bird_uv[1] + "... GOAL => " + next_goal_x + ", " + next_goal_z + "... Next block =>" + next_block);
      Vector3 nextVector = (next_block - position) * 20f;
      nextVector.y *= 20f;
      self.AddForce(nextVector);
      // self.AddForce(next_block);// = new Vector3(next_block[0], 0, next_block[1]) - position;
      // transform.localPosition = next_block;
    }

    // bird.localPosition = position;
    
  }
}
