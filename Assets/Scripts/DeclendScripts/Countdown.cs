using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using SuperPupSystems.Helper;

public class Countdown : MonoBehaviour
{

    public Timer timer;
    public float timeLeft = 100;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        timer.StartTimer();

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = (int)timer.timeLeft;
        Debug.Log(timeLeft);
        text.text = timeLeft.ToString();
    }
}
