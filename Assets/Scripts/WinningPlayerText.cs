using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinningPlayerText : MonoBehaviour
{
    public GameObject winScreen;

    public TMP_Text winner;

    public HealthBar playerOne;
    public HealthBar playerTwo;

    public GameObject playerOneHealth;
    public GameObject playerTwoHealth;

    public GameObject playerOneProtait;
    public GameObject playerTwoProtait;

    public int p2Wins;
    public int p1Wins;
    [SerializeField]
    public RoundManager roundManager;

    private void Awake()
    {
        Debug.Log("Turn off WinScreen");
        winScreen.SetActive(false);
    }
    void Start()
    {
        p2Wins = roundManager.p2Wins;
        p1Wins = roundManager.p1Wins;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOne.currentHealth == 0)
        {
            if (p2Wins >= 2)
            {
                playerOneHealth.SetActive(false);
                playerTwoHealth.SetActive(false);
                playerOneProtait.SetActive(false);
                playerTwoProtait.SetActive(false);
                winScreen.SetActive(true);
                Time.timeScale = 0.0f;
                winner.text = "Player 2 Wins ";
                roundManager.p2Wins = 0;
            }
            else
            {
                roundManager.p2Wins = p2Wins + 1;
                SceneManager.LoadSceneAsync("White_Box");
            }
            
        }
        if (playerTwo.currentHealth == 0)
        {
            if (p1Wins >= 2)
            {

                playerOneHealth.SetActive(false);
                playerTwoHealth.SetActive(false);
                playerOneProtait.SetActive(false);
                playerTwoProtait.SetActive(false);
                winScreen.SetActive(true);
                Time.timeScale = 0.0f;
                winner.text = "Player 1 Wins ";
            }
            else
            {
                roundManager.p1Wins = p1Wins + 1;
                SceneManager.LoadSceneAsync("White_Box");
            }
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
