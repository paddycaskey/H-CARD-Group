using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitController : MonoBehaviour
{
    public GameObject eventSystem;
    public GameObject yesBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = GameManager.instance.avatar;    
    }

    void Update()
    {
        // if eventSystem is not selecting anything, select the yes button
        if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject == null)
        {
            eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(yesBtn);
        }
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
