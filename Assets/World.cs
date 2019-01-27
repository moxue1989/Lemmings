using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	[Range(10,100)] public int world_size;
	int grid_u;
	int grid_v;
	int offset;
	private Texture2D noiseTex;
	[Range(1,6)] public int road_max;
	[Range(0.5f,20)] public float tree_chance;
	[Range(2,50)] public int bird_count;
	public int[,] worldGrid;
	public int[,] navGrid;
	public Transform groundObject;
	public Transform treeObject;
	public Transform roadObject;
	public Transform blueBirdObject;
	public Transform yellowBirdObject;
	public Transform Birds;
	public Transform player;
	public Transform goal;
	public Transform powerUp;
	private bool _gameOver;
	private bool _isWin;
	public Transform Roads;
	public Transform Trees;
	int road_u;
	int road_v;
	public string[,] grid;
	protected internal List<GameObject> GameObjects = new List<GameObject>();

	void Start () {

		grid_u = world_size;
		grid_v = world_size;
		offset = world_size / 2;
		grid = new string[grid_u, grid_v];

		groundObject.localScale = new Vector3(grid_u, 0.1f, grid_v);
    worldGrid = new int[grid_u, grid_v];
        
		for(int i = 0; i < road_max; i++) {
			// make roads
			bool is_u = Random.value > 0.5f;
			int road_coordinate = Random.Range(-7, 7);
			DrawRoad(is_u, road_coordinate);
			
		}

		for(int u = 0; u < grid_u; u++) {
			for(int v = 0; v < grid_v; v++) {
				
				if (worldGrid[u,v] == 0) {
					float rnd = Random.value;
					if( rnd < (tree_chance * 0.01) ) {
						worldGrid[u,v] = GenerateTree(u,v);
					}
				}
			}
		}

		PathingController.get_instance().call_me_first(worldGrid, grid_u, grid_v);
		PathingController.get_instance().recompute_minimums();
			
		for(int i = 0; i < bird_count; i++) {
			bool is_blueBird = Random.value > 0.5f;
			Transform bird = Instantiate(is_blueBird ? blueBirdObject : yellowBirdObject);

			GameObjects.Add(bird.gameObject);

			bird.localPosition = new Vector3(
				Random.Range(-offset,offset),
				2,
				Random.Range(-offset,offset)
			);

			bird.SetParent(Birds, false);

    }

	    int playerX = Random.Range(0, grid_u) - offset;
	    int playerZ = Random.Range(0, grid_v) - offset;

	    int goalX = Random.Range(0, grid_u) - offset;
	    int goalZ = Random.Range(0, grid_v) - offset;

	    int powerUpX = Random.Range(0, grid_u) - grid_u / 2;
	    int powerUpZ = Random.Range(0, grid_v) - grid_v / 2;

	    powerUp.gameObject.SetActive(true);

			powerUp.position = new Vector3(powerUpX, 0.6f, powerUpZ);
			player.position = new Vector3(playerX, 0.6f, playerZ);
	    goal.position = new Vector3(goalX, 0.6f, goalZ);
        
			// call navmesh builder
			// feed result to actor for pathfinding
			// ReturnGridPosition(goalX, goalZ);
		}

    public void reset()
    {
        _gameOver = false;
        foreach (GameObject o in GameObjects)
        {
            Destroy(o);
        }
        Start();
    }

	void DrawRoad (bool is_u, int road_coordinate) {
		for (int k = 0; k < (is_u ? grid_u : grid_v) ; k++) {
			
			Transform road = Instantiate(roadObject);
			GameObjects.Add(road.gameObject);
			road.SetParent(Roads, false);
			road.localPosition = is_u ? new Vector3(road_coordinate,0,k - (offset - .5f)) : new Vector3(k - (offset - .5f),0,road_coordinate);
			if(is_u) {
				road.Rotate(0,90,0);
				worldGrid[road_coordinate + offset, k] = 20;
			} else {
				worldGrid[k, road_coordinate + offset] = 20;
			}
			
		}
	}	

	int[] ReturnGridPosition(float x, float z) {
		int u = Mathf.FloorToInt(x + offset);
		int v = Mathf.FloorToInt(z + offset);
		int[] val = {u,v};
		// Debug.Log(val[0]);
		// Debug.Log(val[1]);
		return val;
	}

	int GenerateTree (int u, int v) {
		Transform tree = Instantiate(treeObject);
	    GameObjects.Add(tree.gameObject);
	    tree.localPosition = new Vector3(
				u - offset,
				Random.value,
				v - offset
			);
		tree.SetParent(Trees, false);
		return 100;
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
