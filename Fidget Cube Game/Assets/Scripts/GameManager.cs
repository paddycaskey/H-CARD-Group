using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lastGamePlayed = 1;
    public Sprite avatar;
    
    public List<int> leaderboardGame1EasyScores = new List<int>();
    public List<int> leaderboardGame1MediumScores = new List<int>();
    public List<int> leaderboardGame1HardScores = new List<int>();

    public List<float> leaderboardGame1EasyTimes = new List<float>();
    public List<float> leaderboardGame1MediumTimes = new List<float>();
    public List<float> leaderboardGame1HardTimes = new List<float>();
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLeaderBoard(int Game, int Level, int points, float timeTaken)
    {
        if (Game == 1)
        {
            if (Level == 1)
            {
                leaderboardGame1EasyScores.Add(points);
                leaderboardGame1EasyTimes.Add(timeTaken);
            }
            else if (Level == 2)
            {
                leaderboardGame1MediumScores.Add(points);
                leaderboardGame1MediumTimes.Add(timeTaken);
            }
            else if (Level == 3)
            {
                leaderboardGame1HardScores.Add(points);
                leaderboardGame1HardTimes.Add(timeTaken);
            }
        }
    }

    public (int score, float time) Game1Easy()
{
    int bestScore = 0;
    float bestTime = 10000;
    for (int i = 0; i < leaderboardGame1EasyScores.Count; i++)
    {
        if (leaderboardGame1EasyScores[i] > bestScore)
        {
            bestScore = leaderboardGame1EasyScores[i];
            bestTime = leaderboardGame1EasyTimes[i];
        }
        else if (leaderboardGame1EasyScores[i] == bestScore && leaderboardGame1EasyTimes[i] < bestTime)
        {
            bestTime = leaderboardGame1EasyTimes[i];
        }
    }
    return (bestScore, bestTime);
}
}
