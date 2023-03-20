using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game1EndController : MonoBehaviour
{   
    private string score;
    private string time;
    private string bestScore;
    private string bestTime;
    public bool passed;
    public int game_num;
    public bool easy;
    public bool medium;
    public bool hard;
    public GameObject Point;
    public GameObject TimeGO;
    public GameObject LeaderScore;
    public GameObject LeaderTime;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject UI_canvas;

    private int maxPoints = 3;
    private float cutOffTime = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowScoreTime();
        if (passed)
        {
            UpdateLeaderBoard();
            UpdateStars();
        }          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScoreTime()
    {
        if (game_num == 1)
        {
            // get score from Point object
            score = Point.GetComponent<UnityEngine.UI.Text>().text;
            GameObject Score = transform.GetChild(2).gameObject;
            Score.GetComponent<UnityEngine.UI.Text>().text = score;

            if (passed && easy)
            {
                // get time from PointsController
                time = PointsController.instance.timeTaken.ToString();
                TimeGO.GetComponent<UnityEngine.UI.Text>().text = time;
            }
            
            UI_canvas.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void UpdateLeaderBoard()
    {
        (int bScore, float bTime) = GameManager.instance.Game1Easy();
        bestScore = bScore.ToString();
        bestTime = bTime.ToString();
        LeaderScore.GetComponent<UnityEngine.UI.Text>().text = bestScore;
        LeaderTime.GetComponent<UnityEngine.UI.Text>().text = bestTime;
    }

    public void UpdateStars()
    {
        if (int.Parse(score) != maxPoints && float.Parse(time) > cutOffTime)
        {
            Star2.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
            Star3.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
        }
        else if (int.Parse(score) != maxPoints || float.Parse(time) > cutOffTime)
        {
            Star3.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
        }
    }
    
    public void RestartGame()
    {
        // load the game scene
        SceneController.instance.FadeToBlack("Game1Easy");
    }

    public void GoToMenu()
    {
        GameManager.instance.lastGamePlayed = 1;
        // load the menu scene
        SceneController.instance.FadeToBlack("Menu");
    }
}
