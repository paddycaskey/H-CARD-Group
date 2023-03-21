using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{    
    public static SceneController instance;
    public bool fadeToBlack = false;
    public bool fadeFromBlack = false;
    private float fadeSpeed = 1f; 
    public string sceneName = "sceneName";
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
            {
                GameObject Fade = transform.GetChild(0).gameObject;
                Color color = Fade.GetComponent<Image>().color;
                // gradually fade to black
                Fade.GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.MoveTowards(color.a, 1f, fadeSpeed * Time.deltaTime));
                if (Fade.GetComponent<Image>().color.a == 1f)
                {
                    fadeToBlack = false;
                    SceneManager.LoadScene(sceneName);
                    fadeFromBlack = true;
                }
            }

            if (fadeFromBlack)
            {
                GameObject Fade = transform.GetChild(0).gameObject;
                Color color = Fade.GetComponent<Image>().color;
                Fade.GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.MoveTowards(color.a, 0f, fadeSpeed * Time.deltaTime));
                if (Fade.GetComponent<Image>().color.a == 0f)
                {
                    fadeFromBlack = false;
                }
            }
    }

    public void FadeToBlack(string scene)
    {
        fadeToBlack = true;
        fadeFromBlack = false;
        sceneName = scene;
    }

    public void FadeFromBlack()
    {
        fadeFromBlack = true;
        fadeToBlack = false;
    }
}
