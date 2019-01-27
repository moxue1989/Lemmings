using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour {

	public GameObject PlayerObject;

	Transform playerTransform;
	Vector3 playerPosition;

public Vector3 offset;
	// Use this for initialization
	void Start () {
		// set player object to be focus point
		playerTransform = PlayerObject.GetComponent<Transform>();
		playerPosition = playerTransform.position;
		Vector3 initialCameraPosition = transform.position;

		transform.localPosition = new Vector3(playerPosition.x,0,playerPosition.z);
		
	}
	
	// Update is called once per frame
	void Update () {
		playerPosition = playerTransform.position;

		transform.localPosition = new Vector3(
			playerPosition.x + offset.x,
			0 + offset.y,
			playerPosition.z + offset.z
		);

	}
}
