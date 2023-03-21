using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour
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

    public GameObject replayBtn;
    public GameObject homeBtn;
    public GameObject eventSystem;

    private int maxPointsGame1Easy = 3;
    private int maxPointsGame2Medium = 25;
    private float cutOffTimeGame1Easy = 10f;
    private float cutOffTimeGame2Medium = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowScoreTime();
        if (passed)
        {
            UpdateLeaderBoard();
            UpdateStars();
        }
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(replayBtn);          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScoreTime()
    // get score and time from PointsController and insert them in canvas Point text and Time text
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
        }
        else if (game_num == 2)
        {
            // get score from Point object
            score = Point.GetComponent<UnityEngine.UI.Text>().text;
            GameObject Score = transform.GetChild(2).gameObject;
            Score.GetComponent<UnityEngine.UI.Text>().text = score;

            // get time from PointsController
            time = PointsController.instance.timeTaken.ToString();
            TimeGO.GetComponent<UnityEngine.UI.Text>().text = time;
        }
    }

    public void UpdateLeaderBoard()
    // Find the best score in the leaderboard and update the screen with the best score and time
    {
        // For game 1
        if (game_num == 1)
        {        
            // For easy mode, get both score and time
            if (easy)
            {
                (int bScore, float bTime) = GameManager.instance.Game1Easy();
                bestScore = bScore.ToString();
                bestTime = bTime.ToString();
                LeaderScore.GetComponent<UnityEngine.UI.Text>().text = bestScore;
                LeaderTime.GetComponent<UnityEngine.UI.Text>().text = bestTime;
            }
            // For hard mode, get only score
            else if (hard)
            {
                int bScore = GameManager.instance.Game1Hard();
                bestScore = bScore.ToString();
                LeaderScore.GetComponent<UnityEngine.UI.Text>().text = bestScore;
            }
        }
        // For game 2
        else if (game_num == 2)
        {
            // For medium mode, get both score and time
            (int bScore, float bTime) = GameManager.instance.Game2Medium();
            bestScore = bScore.ToString();
            bestTime = bTime.ToString();
            LeaderScore.GetComponent<UnityEngine.UI.Text>().text = bestScore;
            LeaderTime.GetComponent<UnityEngine.UI.Text>().text = bestTime;
        }
    }

    public void UpdateStars()
    // Update the stars shown based on the score and time
    {
        // For game 1
        if (game_num == 1)
        {
            // For easy mode
            if (easy)
            {
                // If score is maximum and time is below the cut off, show all stars or else remove accordingly
                if (int.Parse(score) != maxPointsGame1Easy && float.Parse(time) > cutOffTimeGame1Easy)
                {
                    Star2.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
                    Star3.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
                }
                else if (int.Parse(score) != maxPointsGame1Easy || float.Parse(time) > cutOffTimeGame1Easy)
                {
                    Star3.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
                }
            }
            // For hard mode
            else if (hard)
            {
                // if score is more than 130 then show all stars, if score is between 100 and 130 then show 2 stars, if score is less than 100 then show 1 star
                if (int.Parse(score) < 100)
                {
                    Star2.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
                    Star3.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
                }
                else if (int.Parse(score) < 130)
                {
                    Star3.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
                }
            }
        }
        // For game 2
        else if (game_num == 2)
        {
            // If score is maximum and time is below the cut off, show all stars or else remove accordingly
            if (int.Parse(score) != maxPointsGame2Medium && float.Parse(time) > cutOffTimeGame2Medium)
            {
                Star2.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
                Star3.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
            }
            else if (int.Parse(score) != maxPointsGame2Medium || float.Parse(time) > cutOffTimeGame2Medium)
            {
                Star3.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
            }
        }
    }
    
    public void RestartGame()
    {
        // load the game scene
        if (game_num == 1)
        {
            if (easy)
            {
                // load the easy game scene
                SceneController.instance.FadeToBlack("Game1Easy");
            }
            else if (medium)
            {
                // load the medium game scene
            }
            else if (hard)
            {
                // load the hard game scene
                SceneController.instance.FadeToBlack("Game1Hard");
            }
        }
        else if (game_num == 2)
        {
            if (easy)
            {
                // load the easy game scene
            }
            else if (medium)
            {
                // load the medium game scene
                SceneController.instance.FadeToBlack("Game2Medium");
            }
            else if (hard)
            {
                // load the hard game scene
            }
        }
    }

    public void GoToMenu()
    {
        // update the last game played
        GameManager.instance.lastGamePlayed = game_num;
        // load the menu scene
        SceneController.instance.FadeToBlack("Menu");
    }
}
