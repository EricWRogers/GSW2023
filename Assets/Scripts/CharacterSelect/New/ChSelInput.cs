using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChSelInput : MonoBehaviour
{
    ChEventScript eventScript;


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
        
        if (Player1HorizontalAxis != 0.0f)
        {
            if(Player1HorizontalAxis >= 0.1f)
            {
                eventScript.P1Input("Right");
            }
            else if (Player1HorizontalAxis <= -0.1f)
            {
                eventScript.P1Input("Left");
            }
        }
        if (Player1VerticalAxis != 0.0f)
        {
            if(Player1VerticalAxis >= 0.1f)
            {
                eventScript.P1Input("Up");
            }
            else if (Player1VerticalAxis <= -0.1f)
            {
                eventScript.P1Input("Down");
            }
        }

    }
    void FixedUpdate()
    {
        
    }
}
