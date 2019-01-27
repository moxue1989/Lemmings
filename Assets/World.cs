﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	int grid_u = 20;
	int grid_v = 20;
	private Texture2D noiseTex;
	[Range(1,4)] public int road_max;
	[Range(1,50)] public int tree_chance;
	[Range(2,50)] public int bird_count;
	public Transform[,] worldGrid;
	public int[,] navGrid;
	public Transform treeObject;
	public Transform roadObject;
	public Transform blueBirdObject;
	public Transform yellowBirdObject;
	public Transform Birds;
	private bool _gameOver;
	private bool _isWin;

	public Transform Roads;
	public Transform Trees;
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
					if( rnd < (tree_chance * 0.01) ) {
						worldGrid[u,v] = GenerateTree(u,v);
					}
				}
			}
		}

		for(int i = 0; i < bird_count; i++) {
			bool is_blueBird = Random.value > 0.5f;
			Transform bird = Instantiate(is_blueBird ? blueBirdObject : yellowBirdObject);
			bird.localPosition = new Vector3(Random.Range(-8,8),2,Random.Range(-8,8));
			bird.SetParent(Birds, false);

		}

		// call navmesh builder
		// feed result to actor for pathfinding

	}

	void DrawRoad (bool is_u, int road_coordinate) {
		for (int k = 0; k < (is_u ? grid_u : grid_v) ; k++) {
			
			Transform road = Instantiate(roadObject);
			road.SetParent(Roads, false);
			road.localPosition = is_u ? new Vector3(road_coordinate,0,k - 10) : new Vector3(k - 10,0,road_coordinate);
			if(is_u) {
				road.Rotate(0,90,0);
				worldGrid[road_coordinate + 10, k] = road;
			} else {
				worldGrid[k, road_coordinate + 10] = road;
			}
			
		}
	}	
	Transform GenerateTree (int u, int v) {
		Transform tree = Instantiate(treeObject);
		tree.localPosition = new Vector3(u - grid_u/2,1,v - grid_v/2);
		tree.SetParent(Trees, false);
		return tree;
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void endGame(bool isWin)
    {
        _isWin = isWin;
        _gameOver = true;
    }

    public bool isGameOver()
    {
        return _gameOver;
    }

    public bool isWin()
    {
        return _isWin;
    }
}
