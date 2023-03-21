using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2SelectLevelController : MonoBehaviour
{
    public GameObject gameDiffPanel;
    public GameObject mediumInstructPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        gameDiffPanel.SetActive(true);
        mediumInstructPanel.SetActive(false);
    }

    public void ReturnToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void MediumLevelInstruct()
    {
        gameDiffPanel.SetActive(false);
        mediumInstructPanel.SetActive(true);
    }

    public void ReturnToDiff()
    {
        gameDiffPanel.SetActive(true);
        mediumInstructPanel.SetActive(false);
    }

    public void Game2MediumLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game2Medium");
    }
}
