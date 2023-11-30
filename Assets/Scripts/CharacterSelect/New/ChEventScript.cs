using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChEventScript : MonoBehaviour
{
    public GameObject player1Selection;
    public GameObject player2Selection;
    public int player1SelectionInt;
    public int player1ColorInt = 0;
    public int player2SelectionInt;
    public int player2ColorInt = 0;
    public List<Character> charList;
    public GameObject trophyP1;
    public GameObject trophyP2;
    int charListNum;
    int charColorListNum = 3; //4 possible colors, so (list - 1)
    void Start()
    {
        player1Selection = GameObject.Find("Player 1 Selection");
        player2Selection = GameObject.Find("Player 2 Selection");
        charListNum = charList.Count;
        VariableUpdate();
    }
    void Update()
    {  
        if(player1ColorInt == player2ColorInt && player1SelectionInt == player2SelectionInt)
        {
            if(player1ColorInt == 0) { player2ColorInt = 1; }
            if (player1ColorInt == 1) { player2ColorInt = 2; }
            if (player1ColorInt == 2) { player2ColorInt = 3; }
            if (player1ColorInt == 3) { player2ColorInt = 0; }
            VariableUpdate();

        }
        if (GameManager.Instance.MatchWinner == "Player 1")
        {
            trophyP1.SetActive(true);
            trophyP2.SetActive(false);
        }
        if (GameManager.Instance.MatchWinner == "Player 2")
        {
            trophyP1.SetActive(false);
            trophyP2.SetActive(true);
        }
        if (GameManager.Instance.MatchWinner != "Player 1" && GameManager.Instance.MatchWinner != "Player 2")
        {
            trophyP1.SetActive(false);
            trophyP2.SetActive(false);
        }



    }
    public void P1Input(string input)
    {
        switch(input)
        {
            case "Left":
                //move down the index by 1, if at minimum, set it to maximum
                if (player1SelectionInt <= 0)
                {
                    player1SelectionInt = (charListNum - 1);
                }
                else if (player1SelectionInt <= (charListNum - 1))
                {
                    player1SelectionInt = player1SelectionInt - 1;
                }
                player1ColorInt = 0;
                break;
            case "Right":
                //move up index by 1, if at max, set to min
                if (player1SelectionInt >= (charListNum - 1))
                {
                    player1SelectionInt = (charListNum - charListNum);
                }
                else if (player1SelectionInt <= (charListNum - 1))
                {
                    player1SelectionInt++;
                }
                player1ColorInt = 0;
                break;
            case "Up":
                if (player1ColorInt >= (charColorListNum))
                {
                    player1ColorInt = (charColorListNum - charColorListNum);
                }
                else if (player1ColorInt <= (charColorListNum))
                {
                    player1ColorInt ++;
                }
                break;
            case "Down":
                if (player1ColorInt <= 0)
                {
                    player1ColorInt = (charColorListNum);
                }
                else if (player1ColorInt <= (charColorListNum))
                {
                    player1ColorInt = player1ColorInt - 1;
                }
                break;
        }
        if(player1ColorInt == player2ColorInt && input == "Up")
        {
            player1ColorInt = player2ColorInt + 1;
        }
        else if (player1ColorInt == player2ColorInt && input == "Down")
        {
            player1ColorInt = player2ColorInt - 1;
        }
        //SOUND HERE (REMOVE THIS TEXT AND PUT SOUND CODE)
        VariableUpdate();
    }
    public void P2Input(string input)
    {
        switch(input)
        {
            case "Left":
                //move down the index by 1, if at minimum, set it to maximum
                if (player2SelectionInt <= 0)
                {
                    player2SelectionInt = (charListNum - 1);
                }
                else if (player2SelectionInt <= (charListNum - 1))
                {
                    player2SelectionInt = player2SelectionInt - 1;
                }
                player2ColorInt = 0;
                break;
            case "Right":
                //move up index by 1, if at max, set to min
                if (player2SelectionInt >= (charListNum - 1))
                {
                    player2SelectionInt = (charListNum - charListNum);
                }
                else if (player2SelectionInt <= (charListNum - 1))
                {
                    player2SelectionInt++;
                }
                player2ColorInt = 0;
                break;
            case "Up":
                if (player2ColorInt >= (charColorListNum))
                {
                    player2ColorInt = (charColorListNum - charColorListNum);
                }
                else if (player2ColorInt <= (charColorListNum))
                {
                    player2ColorInt ++;
                }
                break;
            case "Down":
                if (player2ColorInt <= 0)
                {
                    player2ColorInt = (charColorListNum);
                }
                else if (player2ColorInt <= (charColorListNum))
                {
                    player2ColorInt = player2ColorInt - 1;
                }
                break;
        }
        if(player1ColorInt == player2ColorInt && input == "Up")
        {
            player2ColorInt = player1ColorInt + 1;
        }
        else if (player1ColorInt == player2ColorInt && input == "Down")
        {
            player2ColorInt = player1ColorInt - 1;
        }
        //SOUND HERE (REMOVE THIS TEXT AND PUT SOUND CODE)
        VariableUpdate();
        
               
    }
    public IEnumerator StartTimer(float duration)
    {
        //SOUND HERE (REMOVE THIS TEXT AND PUT SOUND CODE)
        yield return new WaitForSeconds(duration); //wait for however many seconds specified, 1 is ok
        GameManager.Instance.ChangeScene("Game_Scene");
    }
    void VariableUpdate()
    {
        player1Selection.GetComponent<Image>().sprite = charList[player1SelectionInt].characterSprite;
        player1Selection.GetComponent<Image>().color = charList[player1SelectionInt].colorList[player1ColorInt];
        GameManager.Instance.Player1Selection = charList[player1SelectionInt];
        GameManager.Instance.Player1SelectionColor = charList[player1SelectionInt].colorList[player1ColorInt];



        player2Selection.GetComponent<Image>().sprite = charList[player2SelectionInt].characterSprite;
        player2Selection.GetComponent<Image>().color = charList[player2SelectionInt].colorList[player2ColorInt];
        GameManager.Instance.Player2Selection = charList[player2SelectionInt];
        GameManager.Instance.Player2SelectionColor = charList[player2SelectionInt].colorList[player2ColorInt]; 
    }
}
