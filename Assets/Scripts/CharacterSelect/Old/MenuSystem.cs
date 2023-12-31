using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public bool isReady = false;
    //public Animator player1Animator;
    //public Animator player2Animator;
    public Animator FadeOutAnimator;
    public Animator ConfirmBlinkAnimator;
    public GameObject confirmBox;
    public string White_Box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ConfirmBlinkAnimator.SetTrigger("ConfirmTrigger");
            FadeOutAnimator.SetTrigger("FadeOutTrigger");

        } 
        if(isReady && (FadeOutAnimator.GetCurrentAnimatorStateInfo(0).IsName("BlackCanvasAnim")))
        {
            SceneManager.LoadScene("White_Box");
        }
        if (isReady){confirmBox.SetActive(true);}
        if (!isReady){confirmBox.SetActive(false);}

        //if(player1Animator.GetCurrentAnimatorStateInfo(0).IsName("Player1LeftLoop") && player2Animator.GetCurrentAnimatorStateInfo(0).IsName("Player2LeftLoop"))
       // {
       //     isReady = true;
        //}
       // else
       // {
       //     isReady = false;
       // }
    
    }
}
