using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitController : MonoBehaviour
{
     
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = GameManager.instance.avatar;    
    }

    public void ReturnToMenu()
    {
        GameManager.instance.lastGamePlayed = 0;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
