using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    public GameObject shadow;
    public CharacterControllerXA player;

    // Start is called before the first frame update
    void Awake()
    {
        shadow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.grounded);
        if(player.grounded == true)
        {
            Debug.Log("Player's Shadow On");
            shadow.SetActive(true);
        }
        else
        {
            Debug.Log("Player's Shadow Off");
            shadow.SetActive(false);
        }
    }
}
