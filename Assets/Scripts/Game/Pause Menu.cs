using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Main Menu");
    }
    public void TryAgain()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
