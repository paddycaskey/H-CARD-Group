using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D RB;
    private Vector2 currentPos;
    private int lastInput = 0;

    public bool game_passed = false;
    private bool canMove = true;
    public int speed;
    public GameObject UI_canvas;
    public GameObject end_platform;

    // constants
    private const int MOVE_DISTANCE = 25;
    private const int VERTICAL_FORCE = 100;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        UI_canvas.transform.GetChild(0).gameObject.SetActive(true);
        UI_canvas.transform.GetChild(1).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (canMove)
        {
            if (RB.velocity == Vector2.zero)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    Move(Vector2.left);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    Move(Vector2.right);
                }
                // if fire1 button is pressed ('J')
                else if (Input.GetButtonDown("Fire1"))
                {
                    RB.AddForce(Vector2.up * VERTICAL_FORCE, ForceMode2D.Impulse);
                }
            }
        }

        if (transform.position.y < -5)
        {
            GameFailed();        
        }
        
    }

    private void Move(Vector2 direction)
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
    {
        RB.velocity = Vector2.zero;
        RB.isKinematic = false;
        currentPos = transform.position;
    }

    private void GameFailed()
    {
        UI_canvas.transform.GetChild(1).gameObject.SetActive(true);
        UI_canvas.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        UI_canvas.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
    }

    private void GamePassed()
    {
        UI_canvas.transform.GetChild(1).gameObject.SetActive(true);
        UI_canvas.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        UI_canvas.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            PointsController.instance.AddPoints();
            Destroy(collision.gameObject);
        }
    }

    // when ball collides with a trigger named "Finish" and is not kinematic, pass game
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            if (!game_passed)
            {
                canMove = false;
                // set confetti to activate
                end_platform.transform.GetChild(1).gameObject.SetActive(true);
                end_platform.transform.GetChild(2).gameObject.SetActive(true);
                
                if (RB.velocity == Vector2.zero)
                {
                    PointsController.instance.EndTimer();
                    GameManager.instance.UpdateLeaderBoard(1, 1, PointsController.instance.points, PointsController.instance.timeTaken);

                    Invoke("GamePassed", 2);
                    
                    game_passed = true;
                }
            }           
        }
    }
}
