using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public World _world;
    public World _worldInstance;
    public int _wins = 0;
    public int _loses = 0;

    public bool _playAgain;
    // Start is called before the first frame update
    void Awake()
    {   
        InitGame();
    }

    void InitGame()
    {
        _worldInstance = Instantiate(_world);
        Debug.Log("game started");
    }

    // Update is called once per frame
    void Update()
    {
        if (_worldInstance.isGameOver())
        {
            if (_worldInstance.isWin())
            {
                Debug.Log("game Win");
                _wins++;
            }
            else
            {
                _loses++;
            }

            Destroy(_worldInstance.gameObject);
            InitGame();
        }
    }
}
