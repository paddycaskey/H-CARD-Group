using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game1SelectLevelController : MonoBehaviour
{
    
    public GameObject gameDiffPanel;
    public GameObject easyInstructPanel;
    public GameObject hardInstructPanel;
    
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
    }

    public void HardLevelInstruct()
    {
        gameDiffPanel.SetActive(false);
        easyInstructPanel.SetActive(false);
        hardInstructPanel.SetActive(true);
    }

    public void ReturnToDiff()
    {
        gameDiffPanel.SetActive(true);
        easyInstructPanel.SetActive(false);
        hardInstructPanel.SetActive(false);
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
