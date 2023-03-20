using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    
    public float timerValue = 60;
    public Text timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerValue > 0)
        {
            timerValue -= Time.deltaTime;
        }
        else
        {
            timerValue = 0;
        }
        FormatTime();
    }

    public void FormatTime()
    {
        int minutes = Mathf.FloorToInt(timerValue / 60);
        int seconds = Mathf.FloorToInt(timerValue % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
