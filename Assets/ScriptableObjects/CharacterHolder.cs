using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Character character;
    void Awake()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = character.animations;
        gameObject.GetComponent<CharacterMovement>().speed = character.speed;
        gameObject.GetComponent<SpriteRenderer>().color = character.newColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
