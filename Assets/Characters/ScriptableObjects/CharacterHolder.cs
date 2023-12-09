using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Character character;
    void Start()
    {
        //get game manager player asset and assign it to character variable here.

        if(this.name == "Player 1")
        {
            character = GameManager.Instance.Player1Selection;
            //gameObject.GetComponent<SpriteRenderer>().color = GameManager.Instance.Player1SelectionColor;
        }
        if (this.name == "Player 2")
        {
            character = GameManager.Instance.Player2Selection;
            //gameObject.GetComponent<SpriteRenderer>().color = GameManager.Instance.Player2SelectionColor;
        }
        gameObject.GetComponent<Animator>().runtimeAnimatorController = character.animations;
        gameObject.GetComponent<CharacterMovement>().speed = character.speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
