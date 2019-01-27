using UnityEngine;

public class GameManager : MonoBehaviour
{
    public World _world;
    public GameObject score;
    public GameObject timer;

    public int _wins = 0;
    public int _loses = 0;

    protected internal float MaxTime = 20;
    protected internal float timeRemaining;
    protected internal float startTime;

    // Start is called before the first frame update
    void Awake()
    {
        InitGame();
        startTime = Time.fixedTime;
    }

    void InitGame()
    {
        Debug.Log("game started");
    }

    // Update is called once per frame
    void Update()
    {

        if (_world.isGameOver())
        {
            if (_world.isWin())
            {
                Debug.Log("game Win");
                _wins++;
            }
            else
            {
                _loses++;
            }

            _world.reset();
            score.GetComponent<TextMesh>().text = "Score " + _wins
                                                           + "\nLosses " + _loses;
            startTime = Time.fixedTime;
        }
        else
        {
            float timeRemaining = MaxTime - (Time.fixedTime - startTime);

            if (timeRemaining <= 0)
            {
                _world.endGame(false);
            }

            timer.GetComponent<TextMesh>().text = "" + timeRemaining;
        }
    }
}
