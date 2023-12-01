using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Character character;
    void Awake()
    {
        //get game manager player asset and assign it to character variable here.
        gameObject.GetComponent<Animator>().runtimeAnimatorController = character.animations;
        gameObject.GetComponent<CharacterMovement>().speed = character.speed;
        if(this.name == "Player 1")
        {
            gameObject.GetComponent<SpriteRenderer>().color = GameManager.Instance.Player1SelectionColor;
        }
        if (this.name == "Player 2")
        {
            gameObject.GetComponent<SpriteRenderer>().color = GameManager.Instance.Player2SelectionColor;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
