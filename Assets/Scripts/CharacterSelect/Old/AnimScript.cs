using UnityEngine;
using System.Collections;

public class AnimScript : MonoBehaviour {
    Animator animator;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () 
    {
        bool isAnimationStatePlaying(Animator animator, int animLayer, string stateName) //just call whatever you named the animator, the layer (which should be 0 unless you are adding new ones, and the name of the animation you want to find.)
        {
        if (animator.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
            animator.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
        return true;
        else
        return false;
        }
        
        float Player1HorizontalAxis = Input.GetAxis("Player 1 Horizontal");
        float Player2HorizontalAxis = Input.GetAxis("Player 2 Horizontal");
        
        if(name == "Player 1 Object")
        {
            if(isAnimationStatePlaying(animator,0,"Player1LeftLoop"))
            {
                //GlobalVariables.instance.Player1Selection = "Left Character";
                animator.ResetTrigger("LeftTrigger");
                animator.ResetTrigger("RightTrigger");
            }
            if(isAnimationStatePlaying(animator,0,"Player1RightLoop"))
            {
                //GlobalVariables.instance.Player1Selection = "Right Character";
                animator.ResetTrigger("LeftTrigger");
                animator.ResetTrigger("RightTrigger");
            }
            if(Player1HorizontalAxis <= -.25) //on left input (added -0.25 for deadzone)
            {
                animator.SetTrigger("LeftTrigger");
            }
            if(Player1HorizontalAxis >= 0.25)//on right input (added 0.25 for deadzone)
            {
                animator.SetTrigger("RightTrigger");
            }
        }        
        if(name == "Player 2 Object")
        {
            if(isAnimationStatePlaying(animator,0,"Player2LeftLoop"))
            {
                //GlobalVariables.instance.Player2Selection = "Left Character";
                animator.ResetTrigger("LeftTrigger2");
                animator.ResetTrigger("RightTrigger2");
            }
            if(isAnimationStatePlaying(animator,0,"Player2RightLoop"))
            {
                //GlobalVariables.instance.Player2Selection = "Right Character";
                animator.ResetTrigger("LeftTrigger2");
                animator.ResetTrigger("RightTrigger2");
            }
            if(Player2HorizontalAxis <= -.25) //on left input (added -0.25 for deadzone)
            {
                animator.SetTrigger("LeftTrigger2");
            }
            if(Player2HorizontalAxis >= 0.25)//on right input (added 0.25 for deadzone)
            {
                animator.SetTrigger("RightTrigger2");
            }
        }


    }
}

