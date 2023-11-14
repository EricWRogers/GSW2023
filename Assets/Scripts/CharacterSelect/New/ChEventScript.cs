using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChEventScript : MonoBehaviour
{
    public GameObject player1Selection;
    public GameObject player2Selection;
    public int player1SelectionInt;
    public int player2SelectionInt;
    public Character characterObject;
    public List<Character> charList;
    int charListNum;
    void Start()
    {
        player1Selection = GameObject.Find("Player 1 Selection");
        player2Selection = GameObject.Find("Player 2 Selection");
        charListNum = charList.Count;
    }
    void Update()
    {
        player2Selection.GetComponent<Image>().sprite = charList[player2SelectionInt].characterSprite; // put this in p2input event area

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
                else if (player1SelectionInt <= (charListNum -1))
                {
                    player1SelectionInt = player1SelectionInt - 1;
                }
                break;
            case "Right":
                //move up index by 1, if at max, set to min
                if (player1SelectionInt >= (charListNum - 1))
                {
                    player1SelectionInt = (charListNum - charListNum);
                }
                else if (player1SelectionInt <= (charListNum - 1))
                {
                    player1SelectionInt ++;
                }

                break;
            case "Up":
                print("Up");
                

                break;
            case "Down":
                print("Down");
                

                break;
        }
        player1Selection.GetComponent<Image>().sprite = charList[player1SelectionInt].characterSprite;
        GameManager.Instance.Player1Selection = charList[player1SelectionInt];
    }
    public void P2Input(string input)
    {
        //wait until p1 is done to put anything here, should just copy+paste but with replaced vars
    }
}
