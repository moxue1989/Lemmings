using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	int grid_u = 20;
	int grid_v = 20;
	private Texture2D noiseTex;
	[Range(1,4)] public int road_max;
	Transform[] worldGrid;
	public Transform treeObject;
	
	// Use this for initialization
	void Start () {

		// starting point
		// ending point
		// two roads
		// birds
		// park
		// buildings
		// houses

		worldGrid = new Transform[grid_u * grid_v];

		for(int i = 0; i < road_max; i++) {
			// make roads
		}

		for(int u = 0; u < grid_u; u++) {
			for(int v = 0; v < grid_v; v++) {
				float rnd = Random.Range(0, 10);
				Debug.Log(rnd);
				if( rnd < 1 ) {
					
					Transform tree = Instantiate(treeObject);
					tree.localScale = new Vector3(0.5f,1,0.5f);
					tree.localPosition = new Vector3(u - grid_u/2,1,v - grid_v/2);
					tree.SetParent(transform, false);
					worldGrid[u] = tree;
				}
			}
		}
	}
	
	void GenerateTree () {

	}

	// Update is called once per frame
	void Update () {
		
	}
}
