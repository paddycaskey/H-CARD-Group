using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lastGamePlayed = 1;
    public Sprite avatar;
    
    // leaderboard for game 1 scores and times
    public List<int> leaderboardGame1EasyScores = new List<int>();
    public List<int> leaderboardGame1MediumScores = new List<int>();
    public List<int> leaderboardGame1HardScores = new List<int>();

    public List<float> leaderboardGame1EasyTimes = new List<float>();
    public List<float> leaderboardGame1MediumTimes = new List<float>();
    public List<float> leaderboardGame1HardTimes = new List<float>();

    // leaderboard for game 2 scores and times
    public List<int> leaderboardGame2EasyScores = new List<int>();
    public List<int> leaderboardGame2MediumScores = new List<int>();
    public List<int> leaderboardGame2HardScores = new List<int>();

    public List<float> leaderboardGame2EasyTimes = new List<float>();
    public List<float> leaderboardGame2MediumTimes = new List<float>();
    public List<float> leaderboardGame2HardTimes = new List<float>();
    
    private void Awake()
    {
        // setting instance
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
    // update the leaderboard with the latest game values
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
        else if (Game == 2)
        {
            if (Level == 1)
            {
                leaderboardGame2EasyScores.Add(points);
                leaderboardGame2EasyTimes.Add(timeTaken);
            }
            else if (Level == 2)
            {
                leaderboardGame2MediumScores.Add(points);
                leaderboardGame2MediumTimes.Add(timeTaken);
            }
            else if (Level == 3)
            {
                leaderboardGame2HardScores.Add(points);
                leaderboardGame2HardTimes.Add(timeTaken);
            }
        }
    }

    public (int score, float time) Game1Easy()
    // finding the best score and time for game 1 easy
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

    public int Game1Hard()
    // finding the best score for game 1 hard
    {
        int bestScore = 0;
        for (int i = 0; i < leaderboardGame1HardScores.Count; i++)
        {
            if (leaderboardGame1HardScores[i] > bestScore)
            {
                bestScore = leaderboardGame1HardScores[i];
            }
        }
        return bestScore;
    }

    public (int score, float time) Game2Medium()
    // finding the best score and time for game 2 medium
    {
        int bestScore = 0;
        float bestTime = 10000;
        for (int i = 0; i < leaderboardGame2MediumScores.Count; i++)
        {
            if (leaderboardGame2MediumScores[i] > bestScore)
            {
                bestScore = leaderboardGame2MediumScores[i];
                bestTime = leaderboardGame2MediumTimes[i];
            }
            else if (leaderboardGame2MediumScores[i] == bestScore && leaderboardGame2MediumTimes[i] < bestTime)
            {
                bestTime = leaderboardGame2MediumTimes[i];
            }
        }
        return (bestScore, bestTime);
    }
}
