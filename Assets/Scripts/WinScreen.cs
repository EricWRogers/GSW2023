using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public void Retry()
    {
        GameManager.Instance.ChangeScene("Game_Scene");
    }

    public void MainMenu()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

    public void QuitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
