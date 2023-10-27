using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pips : MonoBehaviour
{
    public RoundManager roundManager;

    public Image p1r1;
    public Image p1r2;
    public Image p1r3;
    public Image p2r1;
    public Image p2r2;
    public Image p2r3;



    void Start()
    {
        p1r1.enabled = false;
        p1r2.enabled = false;
        p1r3.enabled = false;
        p2r1.enabled = false;
        p2r2.enabled = false;
        p2r3.enabled = false;

        if(roundManager.p1Wins >= 1)
        {
            p1r1.enabled = true;
            if(roundManager.p1Wins >= 2)
            {
                p1r2.enabled = true;
            }
        }

        if(roundManager.p2Wins >= 1)
        {
            p2r1.enabled = true;
            if (roundManager.p2Wins >= 2)
            {
                p2r2.enabled = true;
            }
        }
    }
}

