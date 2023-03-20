using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{     
    private Vector2 game1 = new Vector2(640, -327);
    private Vector2 game2 = new Vector2(27f, -246f);
    private Vector2 game3 = new Vector2(-656f, -184f);
    private Vector2 game4 = new Vector2(-48f, 8f);
    private Vector2 game5 = new Vector2(432f, 114f);
    private List<Vector2> gamePos = new List<Vector2>();

    public int game = 1;

    // Start is called before the first frame update
    void Start()
    {
        gamePos.Add(game1);
        gamePos.Add(game2);
        gamePos.Add(game3);
        gamePos.Add(game4);
        gamePos.Add(game5);

        game = GameManager.instance.lastGamePlayed;
        GetComponent<Image>().sprite = GameManager.instance.avatar;
    }

    // Update is called once per frame
    void Update()
    {
        // Select game
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move();
        }

        // Start game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }        
    }

    private void Move()
    {
        //if up keystroke then they move to another position
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (game != 5)
            {
                GetComponent<RectTransform>().anchoredPosition = gamePos[game];
                game++;
            }
        }
        
        //if down keystroke then they move to another position
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (game != 1)
            {
                GetComponent<RectTransform>().anchoredPosition = gamePos[game - 2];
                game--;
            }
        }
    }

    private void StartGame()
    {
        if (game == 1)
        {
            SceneController.instance.FadeToBlack("Game1Easy");
            // SceneManager.LoadScene("Game1Easy");
        }
        else if (game == 2)
        {
            // transform.position = game2;
        }
        else if (game == 3)
        {
            // transform.position = game3;
        }
        else if (game == 4)
        {
            // transform.position = game4;
        }
        else if (game == 5)
        {
            // transform.position = game5;
        }
    }
}
