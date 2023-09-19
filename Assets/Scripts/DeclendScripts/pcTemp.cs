using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pcTemp : MonoBehaviour
{
    public float speed = 40.0f;

    Rigidbody2D rb2d;
    float v = 0.0f;
    float h = 0.0f;
    // Start is called before the first frame update
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate(){
        Vector2 movement = new Vector2(h, v);
        rb2d.AddForce(movement*speed);
    }
}
