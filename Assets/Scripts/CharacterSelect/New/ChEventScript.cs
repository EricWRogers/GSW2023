using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChEventScript : MonoBehaviour
{
    public Sprite player1Selection;
    public Sprite player2Selection;
    public string player1SelName;
    public string player2SelName;
    void Start()
    {
        player1Selection = GameObject.Find("Player 1 Selection").GetComponent<Image>().sprite;
        player1SelName = "Kable";
        player2Selection = GameObject.Find("Player 2 Selection").GetComponent<Image>().sprite;
        player1SelName = "Other Guy";
    }
    void Update()
    {
        
    }
    public void P1Input(string input)
    {
        switch(input)
        {
            case "Left":
                print("Left");

                break;
            case "Right":
                print("Right");
                break;
            case "Up":
                print("Up");
                break;
            case "Down":
                print("Down");
                break;
        }
    }
    public void ImageSet(Sprite target,Sprite newTarget)
    {

    }
}
