using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Backspace))
            SceneManager.LoadScene("BryeMenuTest");

    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
