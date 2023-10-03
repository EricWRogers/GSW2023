// Player Character Manager - Checks for players on gameplay scene, and sets them up.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterManager : MonoBehaviour
{
    public GameObject Player1;
    public SpriteRenderer spriteRenderer1;

    public GameObject Player2;
    public SpriteRenderer spriteRenderer2;

    public Color cloneColor = new Vector4(1,1,1,1);
    void Start()
    {
        if (Player1 == null)
        {
            Player1 = GameObject.Find("Player 1");
        }
        if (Player1 != null)
        {
            if (spriteRenderer1 == null)
            {
                spriteRenderer1 = Player1.GetComponent<SpriteRenderer>();
            }
            if (spriteRenderer1 != null)
            {
                
            }
        }

        if (Player2 == null)
        {
            Player2 = GameObject.Find("Player 2");
        }
        if (Player2 != null)
        {
            if (spriteRenderer2 == null)
            {
                spriteRenderer2 = Player2.GetComponent<SpriteRenderer>();
                
            }
            if (spriteRenderer2 != null)
            {
                spriteRenderer2.color = cloneColor;
            }
        }

    }

    void Update()
    {
        
    }
}
