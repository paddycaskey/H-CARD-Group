using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2SelectLevelController : MonoBehaviour
{
    public GameObject gameDiffPanel;
    public GameObject mediumInstructPanel;

    public GameObject easyBtn;
    public GameObject mediumBackBtn;
    public GameObject mediumNextBtn;
    public GameObject eventSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        gameDiffPanel.SetActive(true);
        mediumInstructPanel.SetActive(false);
    }

    public void ReturnToMenu()
    {
        // update the last game played
        GameManager.instance.lastGamePlayed = 2;
        SceneController.instance.FadeToBlack("Menu");
    }

    public void MediumLevelInstruct()
    {
        gameDiffPanel.SetActive(false);
        mediumInstructPanel.SetActive(true);
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(mediumNextBtn);
    }

    public void ReturnToDiff()
    {
        gameDiffPanel.SetActive(true);
        mediumInstructPanel.SetActive(false);
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(easyBtn);
    }

    public void Game2MediumLevel()
    {
        SceneController.instance.FadeToBlack("Game2Medium");
    }
}
