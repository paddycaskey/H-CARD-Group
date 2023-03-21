using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBallController : MonoBehaviour
{
    public Rigidbody2D RB;
    public float speed = 25f;
    public float countDown = 10f;

    private bool gameStarted;
    
    public bool canMoveUp = true;
    public bool canMoveDown = false;
    public bool canMoveLeft = false;
    public bool canMoveRight = false;

    private bool yellow;
    private bool green;
    private bool pink;
    private bool blue;
    private bool gamePassed;
    public GameObject challenger;
    public GameObject finalStop;
    public GameObject canvas;

    private bool canMove;
    private bool inChallenge;

    private KeyCode joystickUp = KeyCode.UpArrow;
    private KeyCode joystickDown = KeyCode.DownArrow;
    private KeyCode joystickLeft = KeyCode.LeftArrow;
    private KeyCode joystickRight = KeyCode.RightArrow;
    private KeyCode buttons = KeyCode.Space;
    private KeyCode pressureSensor = KeyCode.N;
    private KeyCode switchbtn = KeyCode.M;
    private KeyCode rotary = KeyCode.B;
    
    // Start is called before the first frame update
    void Start()
    {
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        Movement();
        Challenge();
    }

    public void Movement()
    {
        // To Move the ball
        if (canMove && !inChallenge)
        {    
            if (Input.GetKeyDown(joystickUp) && canMoveUp)
            {
                MoveUp();
                StartGameTimer();
            }
            else if (Input.GetKeyDown(joystickDown) && canMoveDown)
            {
                MoveDown();
                StartGameTimer();
            }
            else if (Input.GetKeyDown(joystickLeft) && canMoveLeft)
            {
                MoveLeft();
                StartGameTimer();
            }
            else if (Input.GetKeyDown(joystickRight) && canMoveRight)
            {
                MoveRight();
                StartGameTimer();
            }
        }
    }
    
    private void MoveUp()
    // move up
    {
        RB.velocity = new Vector2(0, speed);
        canMove = false;
    }

    private void MoveDown()
    // move down
    {
        RB.velocity = new Vector2(0, -speed);
        canMove = false;
    }

    private void MoveLeft()
    // move left
    {
        RB.velocity = new Vector2(-speed, 0);
        canMove = false;
    }

    private void MoveRight()
    // move right
    {
        RB.velocity = new Vector2(speed, 0);
        canMove = false;
    }
    
    private void StartGameTimer()
    // start the game timer
    {
        if (!gameStarted)
            {
                PointsController.instance.StartTimer();
                gameStarted = true;
            }
    }
    
    public void Challenge()
    // setting game rules for challenge. Add 5 points if challenge is complete and destroy the challenge
    {
        if (inChallenge)
        {
            if ((yellow && Input.GetKeyDown(switchbtn)) || 
                (green && Input.GetKeyDown(pressureSensor)) || 
                (pink && Input.GetKeyDown(buttons)) || 
                (blue && Input.GetKeyDown(rotary)))
            {
                inChallenge = false;
                Destroy(challenger);
                PointsController.instance.AddPoints(5);
            }
        }
    }

    private void GamePassed()
    // bring up the passed screen when game is passed
    {
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        canvas.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        canvas.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // whenever ball is in a position where it can make a decision
        if (other.gameObject.CompareTag("Stop"))
        {
            // stop the ball
            RB.velocity = new Vector2(0, 0);
        }
        // whenever ball reaches a colored square
        if (other.gameObject.CompareTag("Challenger"))
        {
            // start the challenge
            yellow = other.gameObject.GetComponent<ChallengeController>().yellow;
            green = other.gameObject.GetComponent<ChallengeController>().green;
            pink = other.gameObject.GetComponent<ChallengeController>().pink;
            blue = other.gameObject.GetComponent<ChallengeController>().blue;
            inChallenge = true;
            challenger = other.gameObject;
            transform.position = other.gameObject.GetComponent<ChallengeController>().stop.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // update allowed positions when ball reaches a position where it can make a decision
        if (other.gameObject.CompareTag("Stop"))
        {
            // get the values from StopController
            canMoveUp = other.gameObject.GetComponent<StopController>().canMoveUp;
            canMoveDown = other.gameObject.GetComponent<StopController>().canMoveDown;
            canMoveLeft = other.gameObject.GetComponent<StopController>().canMoveLeft;
            canMoveRight = other.gameObject.GetComponent<StopController>().canMoveRight;
            canMove = true;

            // when ball reaches destination
            if (other.gameObject == finalStop)
            {
                // set confetti to activate
                finalStop.transform.GetChild(0).gameObject.SetActive(true);
                finalStop.transform.GetChild(1).gameObject.SetActive(true);
            
                // to prevent code from running too many times
                if (!gamePassed)
                {
                    // end timer, update leaderboard and pass game
                    PointsController.instance.EndTimer();
                    GameManager.instance.UpdateLeaderBoard(2, 2, PointsController.instance.points, PointsController.instance.timeTaken);

                    Invoke("GamePassed", 2);
                    gamePassed = true;
                }
            }
        }
    }
}
