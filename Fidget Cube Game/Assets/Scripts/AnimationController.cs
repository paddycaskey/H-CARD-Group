using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public GameObject logo;
    public GameObject logoPanel;
    public GameObject instructions;

    public float animSpeed = 0.01f;
    public float startTime;
    private bool justStarted;

    public bool logoGrowAnim;
    public bool waitAnim1;
    public bool logoGoAnim;
    public bool waitAnim2;
    public bool nextSceneAnim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        logoPanel.SetActive(true);
        logo.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        logoGrowAnim = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (logoGrowAnim)
        {
            LogoGrowAnimation();
        }
        else if (waitAnim1)
        {
            waitForSeconds(startTime, 2);
        }
        else if (logoGoAnim)
        {
            LogoGoAnimation();
        }
        else if (waitAnim2)
        {
            waitForSeconds(startTime, 5);
        }
        else if (nextSceneAnim)
        {
            SceneController.instance.FadeToBlack("Avatar");
        }
        
    }

    private void LogoGrowAnimation()
    {
        // as time increases, increase logo size until it reaches original size
        if (logo.GetComponent<RectTransform>().localScale.x < 1)
        {
            logo.GetComponent<RectTransform>().localScale += new Vector3(animSpeed, animSpeed, animSpeed);
        }
        else
        {
            logo.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            logoGrowAnim = false;
            waitAnim1 = true;
            logoGoAnim = false;
            waitAnim2 = false;
            float startTime = Time.time;
        }
    }

    private void waitForSeconds(float startTime, float time)
    {
        float endTime = Time.time;
        if (endTime - startTime > time)
        {
            if (waitAnim1)
            {
                logoGoAnim = true;
                nextSceneAnim = false;
            }
            else
            {
                logoGoAnim = false;
                nextSceneAnim = true;
            }
            logoGrowAnim = false;
            waitAnim1 = false;
            waitAnim2 = false;
        }
    }
    
    private void LogoGoAnimation()
    {
        // as time increases, move logo to the right until it goes out of screen
        if (instructions.GetComponent<RectTransform>().anchoredPosition.y > -0.1)
        {
            logo.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -animSpeed * 50);
            instructions.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -animSpeed * 50);
        }
        else
        {
            logo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1000);
            instructions.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            logoGrowAnim = false;
            waitAnim1 = false;
            logoGoAnim = false;
            waitAnim2 = true;
            startTime = Time.time;
        }
    }

    
}
