using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
  Transform bird;
  bool found_goal;
  int[] primary_goal;
  int[] secondary_goal;
  int[] next_block;
  public float offset;
  // Use this for initialization
  public virtual void Start()
  {
    // get primary goal
    // get secondary goal
    
    primary_goal = new int[] { GetRandomInt(), GetRandomInt() };
    secondary_goal = new int[] { GetRandomInt(), GetRandomInt() };

    bird = transform;
    offset = Random.value;
  }

  int GetRandomInt() {
    return Mathf.FloorToInt(Random.Range(-10,10));
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "Ground")
    {
      transform.localEulerAngles = new Vector3(0, 45, 0);
    }

  }
  // Update is called once per frame
  public virtual void Update()
  {

    Vector3 position = bird.position;
    Quaternion rotation = bird.rotation;

    position.y += Mathf.Sin(Time.time * offset * Mathf.PI * 2) / 20;
    position.y += Mathf.Sin(Time.time * Mathf.PI * 4) / 50;
    
    int next_goal_x = found_goal ? primary_goal[0] : secondary_goal[0];
    int next_goal_z = found_goal ? primary_goal[1] : secondary_goal[1];
    next_block = new int[2];
    next_block = PathingController.get_instance().query_graph(next_goal_x, next_goal_z);
    
    // Vector3 birdVector = new Vector3(next_block[0], 0, next_block[1]) - position;

    bird.localPosition = position;
    
  }
}
