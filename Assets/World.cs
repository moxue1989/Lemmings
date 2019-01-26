using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	int grid_u = 20;
	int grid_v = 20;
	private Texture2D noiseTex;
	[Range(1,4)] public int road_max;
	Transform[,] worldGrid;
	public Transform treeObject;
	public Transform roadObject;
	
	int road_u;
	int road_v;

	// Use this for initialization
	void Start () {

		// N roads
		// birds
		// park
		// buildings
		// houses

		worldGrid = new Transform[grid_u, grid_v];

		for(int i = 0; i < road_max; i++) {
			// make roads
			bool is_u = Random.value > 0.5f;
			int road_coordinate = Random.Range(-7, 7);
			DrawRoad(is_u, road_coordinate);
		}

		for(int u = 0; u < grid_u; u++) {
			for(int v = 0; v < grid_v; v++) {
				
				if (worldGrid[u,v] == null) {
				
					float rnd = Random.value;
					if( rnd < 0.02 ) {
						Transform tree = Instantiate(treeObject);
						tree.localPosition = new Vector3(u - grid_u/2,1,v - grid_v/2);
						tree.SetParent(transform, false);
						worldGrid[u,v] = tree;
					}
				}
			}
		}
	}

	void DrawRoad (bool is_u, int road_coordinate) {
		for (int k = 0; k < (is_u ? grid_u : grid_v) ; k++) {
			
			Transform road = Instantiate(roadObject);
			road.SetParent(transform, false);
			road.localPosition = is_u ? new Vector3(road_coordinate,0,k - 10) : new Vector3(k - 10,0,road_coordinate);
			if(is_u) {
				road.Rotate(0,90,0);
				worldGrid[road_coordinate + 10, k] = road;
			} else {
				worldGrid[k, road_coordinate + 10] = road;
			}
			
		}
	}	
	void GenerateTree () {

	}

	// Update is called once per frame
	void Update () {
		
	}
}
