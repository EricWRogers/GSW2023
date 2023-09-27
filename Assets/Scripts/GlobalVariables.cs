//USAGE
//in any script, type *GlobalVariables.instance.[VARIABLE NAME HERE]* and set/get what you need. ensure the game loads with the gameobject with this script inside of an empty gameobject.
//Will eventually need to put it in a sort of "Master Scene" to load first, then load whatever new scenes are neccesary.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public string Player1Selection;
    public string Player2Selection;
    public string MatchWinner;
    public string SelectedStage = "Default"; //dont need this just yet


    public static GlobalVariables instance { get; private set; }

    public void Awake()
    {
        // Make an instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

    }
}