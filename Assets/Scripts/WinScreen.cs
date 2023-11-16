using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadSceneAsync("Game_Scene");
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
