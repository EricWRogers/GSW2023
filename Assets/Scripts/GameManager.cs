//USAGE -- in any script, type 'GameManager.Instance.[VARIABLE NAME HERE]' and set/get what you need. ensure the gamescene you need this in loads with this script inside of an empty gameobject.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Character Player1Selection;
    public Color Player1SelectionColor = Color.white;
    public Character Player2Selection;
    public Color Player2SelectionColor = Color.white;
    public string MatchWinner;
    public string SelectedStage = "Default";
    public static GameManager Instance { get; private set; } = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
