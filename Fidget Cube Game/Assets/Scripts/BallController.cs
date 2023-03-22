using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D RB;
    private Vector2 currentPos;
    private int lastInput = 0;

    public bool easy;
    public bool medium;
    public bool hard;
    public bool game_passed = false;
    private bool canMove = true;
    public int speed;
    public GameObject canvas;
    public GameObject end_platform;

    public bool game1hard_complete = false;

    // constants
    private const int MOVE_DISTANCE = 25;
    private const int VERTICAL_FORCE = 100;

    // private KeyCode joystickUp = KeyCode.UpArrow;
    // private KeyCode joystickDown = KeyCode.DownArrow;
    private KeyCode joystickLeft = KeyCode.LeftArrow;
    private KeyCode joystickRight = KeyCode.RightArrow;
    private KeyCode buttons = KeyCode.Space;
    // private KeyCode pressureSensor = KeyCode.N;
    // private KeyCode switchbtn = KeyCode.M;
    // private KeyCode rotary = KeyCode.B;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
    }

    private void Update()
    {
        // Ball moving
        if (canMove)
        {
            if (RB.velocity == Vector2.zero)
            {
                if (Input.GetKeyDown(joystickLeft))
                {
                    Move(Vector2.left);
                }
                else if (Input.GetKeyDown(joystickRight))
                {
                    Move(Vector2.right);
                }
                else if (Input.GetKeyDown(buttons))
                {
                    RB.AddForce(Vector2.up * VERTICAL_FORCE, ForceMode2D.Impulse);
                }
            }
        }

        // Ball falls off the screen
        if (transform.position.y < -5)
        {
            GameFailed();        
        }

        // Game 1 Hard ends
        if (hard)
        {
            game1hard_complete = TimerController.instance.game_ended;
            if (game1hard_complete)
            {
                Game1HardEnd();
            }
        } 
    }
    
    private void Move(Vector2 direction)
    // Move the ball in the direction specified
    {
        currentPos = transform.position;
        RB.isKinematic = true;
        RB.velocity = direction * speed;

        // Start counting time from first movement
        if (lastInput == 0)
        {
            PointsController.instance.StartTimer();
        }
        
        if (direction == Vector2.left)
        {
            lastInput = 1;
        }
        else if (direction == Vector2.right)
        {
            lastInput = 2;
        }
    }

    private void FixedUpdate()
    // Stop the ball when it reaches the its move distance laterally
    {
        if (lastInput == 1 && transform.position.x <= currentPos.x - MOVE_DISTANCE)
        {
            StopMoving();
        }
        else if (lastInput == 2 && transform.position.x >= currentPos.x + MOVE_DISTANCE)
        {
            StopMoving();
        }
    }

    private void StopMoving()
    // stops the ball movement entirely
    {
        RB.velocity = Vector2.zero;
        RB.isKinematic = false;
        // find the multiple of 25 that the x coordinate of the ball is closest to
        float x = Mathf.Round(transform.position.x / 25) * 25;
        Debug.Log(x);
        transform.position = new Vector2(x, transform.position.y);
        currentPos = transform.position;
    }

    private void GameFailed()
    // turning on screens that reflect game loss
    {
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        canvas.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
    }

    private void GamePassed()
    // turning on screens that reflect game win
    {
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        canvas.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        canvas.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
    }

    private void Game1HardEnd()
    // updating leaderboard and turning on screens that reflect game win for game 1 hard
    {
        canMove = false;
        GameManager.instance.UpdateLeaderBoard(1, 3, PointsController.instance.points, 60f);
        // set confetti to activate
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        Invoke("GamePassed", 4);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // add points whenever jumping on a platform
        if (collision.gameObject.tag == "Point")
        {
            PointsController.instance.AddPoints(1);
            Destroy(collision.gameObject);
        }
        // adds 5 points when collecting a coin
        else if (collision.gameObject.tag == "Coin")
        {
            PointsController.instance.AddPoints(5);
            Destroy(collision.gameObject);
        }
    }

    // when ball collides with a trigger named "Finish" and is not kinematic, pass game
    void OnTriggerStay2D(Collider2D collision)
    {
        // finish game when ball collides with finish platform
        if (collision.gameObject.tag == "Finish")
        {
            // to prevent code from running multiple times
            if (!game_passed)
            {
                canMove = false;
                // set confetti to activate
                end_platform.transform.GetChild(1).gameObject.SetActive(true);
                end_platform.transform.GetChild(2).gameObject.SetActive(true);
                
                if (RB.velocity == Vector2.zero)
                {
                    // end timer and update game 1 easy leaderboard
                    PointsController.instance.EndTimer();
                    GameManager.instance.UpdateLeaderBoard(1, 1, PointsController.instance.points, PointsController.instance.timeTaken);

                    Invoke("GamePassed", 2);
                    
                    game_passed = true;
                }
            }           
        }
    }
}
