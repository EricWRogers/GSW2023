using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private void Awake()
    {
        Debug.Log("Turn off WinScreen");
        winScreen.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(playerOne.currentHealth == 0)
        {
            playerOneHealth.SetActive(false);
            playerTwoHealth.SetActive(false);
            playerOneProtait.SetActive(false);
            playerTwoProtait.SetActive(false);
            winScreen.SetActive(true);
            Time.timeScale = 0.0f;
            winner.text = "Player 2 Wins ";
        }
        if (playerTwo.currentHealth == 0)
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
            Time.timeScale = 1.0f;
        }
    }
}
