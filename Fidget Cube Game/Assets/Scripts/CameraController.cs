using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // attach camera to player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -20);
    }

    // Update is called once per frame
    void Update()
    {
        // attach camera to player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -20);
    }
}
