using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D RB;
    private Vector2 currentPos;
    private int lastInput;

    public int speed;

    // constants
    private const int MOVE_DISTANCE = 25;
    private const int MOVE_UP_DISTANCE = 25;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (RB.velocity == Vector2.zero)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(Vector2.left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(Vector2.right);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                Move(Vector2.up);
            }
        }
    }

    private void Move(Vector2 direction)
    {
        currentPos = transform.position;
        RB.isKinematic = true;
        RB.velocity = direction * speed;

        if (direction == Vector2.left)
        {
            lastInput = 1;
        }
        else if (direction == Vector2.right)
        {
            lastInput = 2;
        }
        else if (direction == Vector2.up)
        {
            lastInput = 3;
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
        else if (lastInput == 3 && transform.position.y >= currentPos.y + MOVE_UP_DISTANCE)
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        PointsController.instance.AddPoints();
        Destroy(collision);
    }
}
