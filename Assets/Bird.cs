using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
  Transform bird;
  public float offset;
  // Use this for initialization
  public virtual void Start()
  {
    bird = transform;
    offset = Random.value;
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
    bird.localPosition = position;
  }
}
