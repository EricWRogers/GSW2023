using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //move this outta here soon

public class ChSelInput : MonoBehaviour
{
    ChEventScript eventScript;
    bool Player1HorizontalAxisInUse = false;
    bool Player1VerticalAxisInUse = false;
    bool Player2HorizontalAxisInUse = false;
    bool Player2VerticalAxisInUse = false;

    void Start()
    {
        eventScript = GetComponent<ChEventScript>();
        
    }
    void Update()
    {
        float Player1HorizontalAxis = Input.GetAxis("Player 1 Horizontal");
        float Player2HorizontalAxis = Input.GetAxis("Player 2 Horizontal");
        float Player1VerticalAxis = Input.GetAxis("Player 1 Vertical");
        float Player2VerticalAxis = Input.GetAxis("Player 2 Vertical");

        if (Player1HorizontalAxis != 0.0f || Input.GetAxis("Player 1 Horizontal Axis") != 0.0f)
        {
            if(!Player1HorizontalAxisInUse)
            {
                if(Player1HorizontalAxis >= 0.1f || Input.GetAxis("Player 1 Horizontal Axis") >= 0.1f)
                {
                    eventScript.P1Input("Right");
                    Player1HorizontalAxisInUse = true;
                }
                else if (Player1HorizontalAxis <= -0.1f || Input.GetAxis("Player 1 Horizontal Axis") <= -0.1f)
                {
                    eventScript.P1Input("Left");
                    Player1HorizontalAxisInUse = true;
                }
            }
        }
        if (Player1VerticalAxis != 0.0f || Input.GetAxis("Player 1 Vertical Axis") != 0.0f)
        {
            if(!Player1VerticalAxisInUse)
            {
                if(Player1VerticalAxis >= 0.1f || Input.GetAxis("Player 1 Vertical Axis") >= 0.1f)
                {
                    eventScript.P1Input("Up");
                    Player1VerticalAxisInUse = true;
                }
                else if (Player1VerticalAxis <= -0.1f || Input.GetAxis("Player 1 Vertical Axis") <= -0.1f)
                {
                    eventScript.P1Input("Down");
                    Player1VerticalAxisInUse = true;
                }
            }
        }
        if (Player1HorizontalAxis == 0.0f && Input.GetAxis("Player 1 Horizontal Axis") == 0.0f)
        {
            Player1HorizontalAxisInUse = false;
        }
        if (Player1VerticalAxis == 0.0f && Input.GetAxis("Player 1 Vertical Axis") == 0.0f)
        {
            Player1VerticalAxisInUse = false;
        }

        if (Player2HorizontalAxis != 0.0f)
        {
            if(!Player2HorizontalAxisInUse)
            {
                if(Player2HorizontalAxis >= 0.1f)
                {
                    eventScript.P2Input("Right");
                    Player2HorizontalAxisInUse = true;
                }
                else if (Player2HorizontalAxis <= -0.1f)
                {
                    eventScript.P2Input("Left");
                    Player2HorizontalAxisInUse = true;
                }
            }
        }
        if (Player2VerticalAxis != 0.0f)
        {
            if(!Player2VerticalAxisInUse)
            {
                if(Player2VerticalAxis >= 0.1f)
                {
                    eventScript.P2Input("Up");
                    Player2VerticalAxisInUse = true;
                }
                else if (Player2VerticalAxis <= -0.1f)
                {
                    eventScript.P2Input("Down");
                    Player2VerticalAxisInUse = true;
                }
            }
        }
        if (Player2HorizontalAxis == 0.0f)
        {
            Player2HorizontalAxisInUse = false;
        }
        if (Player2VerticalAxis == 0.0f)
        {
            Player2VerticalAxisInUse = false;
        }

        if (Input.GetButtonDown("Space Bar") || Input.GetButtonDown("Start"))
        {
            SceneManager.LoadSceneAsync("Game_Scene");
        }
    }
    void FixedUpdate()
    {
        
    }
}
