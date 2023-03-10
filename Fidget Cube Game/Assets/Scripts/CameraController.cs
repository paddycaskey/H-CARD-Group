using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   

    public GameObject player;
    public GameObject bg;
    public GameObject scoreBoard;
    public GameObject suggestedMoveBoard;

    // Start is called before the first frame update
    void Start()
    {
        // attach camera to player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -20);
        // attach scoreBoard to top left of the camera orthographic viewport
        scoreBoard.transform.position = new Vector3(transform.position.x - 55, transform.position.y + 27, 0);
        // attach suggestedMoveBoard to top right of the camera
        suggestedMoveBoard.transform.position = new Vector3(transform.position.x + 55, transform.position.y + 27, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // attach camera to player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -20);
        // attach scoreBoard to top left of the camera
        scoreBoard.transform.position = new Vector3(transform.position.x - 55, transform.position.y + 27, 0);
        // attach suggestedMoveBoard to top right of the camera
        suggestedMoveBoard.transform.position = new Vector3(transform.position.x + 55, transform.position.y + 27, 0);
    }
}
