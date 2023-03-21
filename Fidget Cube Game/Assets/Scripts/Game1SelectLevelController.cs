using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game1SelectLevelController : MonoBehaviour
{
    
    public GameObject gameDiffPanel;
    public GameObject easyInstructPanel;
    public GameObject hardInstructPanel;
    
    public GameObject easyBtn;
    public GameObject hardBtn;
    public GameObject easyBackBtn;
    public GameObject easyNextBtn;
    public GameObject hardBackBtn;
    public GameObject hardNextBtn;
    public GameObject eventSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        gameDiffPanel.SetActive(true);
        easyInstructPanel.SetActive(false);
        hardInstructPanel.SetActive(false);
    }

    public void ReturnToMenu()
    {
        // update the last game played
        GameManager.instance.lastGamePlayed = 1;
        SceneController.instance.FadeToBlack("Menu");
    }

    public void EasyLevelInstruct()
    {
        gameDiffPanel.SetActive(false);
        easyInstructPanel.SetActive(true);
        hardInstructPanel.SetActive(false);
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(easyNextBtn);
    }

    public void HardLevelInstruct()
    {
        gameDiffPanel.SetActive(false);
        easyInstructPanel.SetActive(false);
        hardInstructPanel.SetActive(true);
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(hardNextBtn);
    }

    public void ReturnToDiff()
    {
        gameDiffPanel.SetActive(true);
        easyInstructPanel.SetActive(false);
        hardInstructPanel.SetActive(false);
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(easyBtn);
    }

    public void Game1EasyLevel()
    {
        SceneController.instance.FadeToBlack("Game1Easy");
    }

    public void Game1HardLevel()
    {
        SceneController.instance.FadeToBlack("Game1Hard");
    }


}
