using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSetColor : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    void Start()
    {
        
        //GameManager.Instance.Player1SelectionColor
        SpriteRenderer renderP1 = player1.GetComponent<SpriteRenderer>();
        SpriteRenderer renderP2 = player2.GetComponent<SpriteRenderer>();
        Color whiteColor = new Color(1f,1f,1f,1f);
        Color redColor = new Color(1f,0f,0f,1f);
        Color blueColor = new Color(0f,0f,1f,1f);

        renderP1.material.SetColor("_OutlineColor", blueColor);
        renderP2.material.SetColor("_OutlineColor", redColor);
        renderP1.material.SetColor("_SpriteColor", GameManager.Instance.Player1SelectionColor);
        renderP2.material.SetColor("_SpriteColor", GameManager.Instance.Player2SelectionColor);
        renderP1.material.SetFloat("_OutlineThickness", GameManager.Instance.Player1Selection.outlineThickness);
        renderP2.material.SetFloat("_OutlineThickness", GameManager.Instance.Player2Selection.outlineThickness);
    }

    void Update()
    {
        
    }
}
