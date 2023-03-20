using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    public int game;
    public int level;
    public bool showScore;
    public bool showTime;
    public List<int> scores;
    public List<float> times;
    
    // Start is called before the first frame update
    void Start()
    {
        if (game == 1)
        {
            if (level == 1)
            {
                scores = GameManager.instance.leaderboardGame1EasyScores;
                times = GameManager.instance.leaderboardGame1EasyTimes;
            }
            else if (level == 2)
            {
                scores = GameManager.instance.leaderboardGame1MediumScores;
                times = GameManager.instance.leaderboardGame1MediumTimes;
            }
            else if (level == 3)
            {
                scores = GameManager.instance.leaderboardGame1HardScores;
                times = GameManager.instance.leaderboardGame1HardTimes;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Game1Level1(List<float> times)
    {
        float bestTime = 10000;
        for (int i = 0; i < times.Count; i++)
        {
            if (times[i] < bestTime)
            {
                bestTime = times[i];
            }
        }
        return bestTime;
    }
}
