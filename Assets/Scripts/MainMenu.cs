using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("CharacterSelect");
    }

    public void CreditScene()
    {
        SceneManager.LoadSceneAsync("Credit_Menu");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
