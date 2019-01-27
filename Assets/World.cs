using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	[Range(10,100)] public int world_size;
	int grid_u;
	int grid_v;
	int offset;
	private Texture2D noiseTex;
	[Range(1,4)] public int road_max;
	[Range(1,50)] public int tree_chance;
	[Range(2,50)] public int bird_count;
	public Transform[,] worldGrid;
	public int[,] navGrid;
	public Transform groundObject;
	public Transform treeObject;
	public Transform roadObject;
	public Transform blueBirdObject;
	public Transform yellowBirdObject;
	public Transform Birds;
	public Transform player;
	private bool _gameOver;
	private bool _isWin;
	public Transform Roads;
	public Transform Trees;
	int road_u;
	int road_v;
	protected internal List<GameObject> GameObjects = new List<GameObject>();

	void Start () {

		grid_u = world_size;
		grid_v = world_size;
		offset = world_size / 2;

		
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

		    GameObjects.Add(bird.gameObject);

        bird.localPosition = new Vector3(Random.Range(-offset,offset),2,Random.Range(-offset,offset));
			bird.SetParent(Birds, false);

		}

		// call navmesh builder
		// feed result to actor for pathfinding

	}

    public void reset()
    {
        _gameOver = false;
        foreach (GameObject o in GameObjects)
        {
            Destroy(o);
        }
        Start();
        player.position = new Vector3(-8f, 0.6f, 8f);
    }

	void DrawRoad (bool is_u, int road_coordinate) {
		for (int k = 0; k < (is_u ? grid_u : grid_v) ; k++) {
			
			Transform road = Instantiate(roadObject);
		    GameObjects.Add(road.gameObject);
            road.SetParent(Roads, false);
			road.localPosition = is_u ? new Vector3(road_coordinate,0,k - 9.55f) : new Vector3(k - 9.55f,0,road_coordinate);
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
	    GameObjects.Add(tree.gameObject);
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
