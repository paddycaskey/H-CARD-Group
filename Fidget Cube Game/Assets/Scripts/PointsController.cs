using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    public static PointsController instance;
    public Text pointsText;

    public int points = 0;
    private float startTime;
    private float endTime;
    public float timeTaken;
    
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

    public void AddPoints(int value)
    // Add a value of points
    {
        points += value;
        pointsText.text = points.ToString();
    }

    public void StartTimer()
    // Start the timer
    {
        startTime = Time.time;
    }

    public void EndTimer()
    // End the timer
    {
        endTime = Time.time;
        timeTaken = endTime - startTime;
        timeTaken = Mathf.Round(timeTaken * 100f) / 100f;
    }
}
