using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    public static PointsController instance;
    
    // add a text variable called points
    public Text pointsText;
    public int points = 0;
    
    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // set the points text to 0
        pointsText.text = "0";
    }

    public void AddPoints()
    {
        points += 1;
        pointsText.text = points.ToString();
    }
}
