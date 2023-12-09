using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyFightText : MonoBehaviour
{
    //show text
    public GameObject readyText;
    public GameObject fightText;
    //play sound 
    private void Awake()
    {
        Time.timeScale = 0.0f;
        PlayText();
    }
    public void PlayText()
    {
        StartCoroutine(BeginningText());
    }

    private IEnumerator BeginningText()
    {
        readyText.SetActive(true);
        fightText.SetActive(false);
        yield return new WaitForSecondsRealtime(2.0f);
        readyText.SetActive(false);
        fightText.SetActive(true);
        yield return new WaitForSecondsRealtime(2.0f);
        readyText.SetActive(false);
        fightText.SetActive(false);
        yield return null;
    }

    private void Update()
    {
        if(!IsInvoking("PlayText"))
        {
            Time.timeScale = 1.0f;
        }
    }
}
