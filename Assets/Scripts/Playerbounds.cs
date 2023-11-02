using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbounds : MonoBehaviour
{
    private float wall1 = -9.0160f;
    private float wall2 = 9.0160f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < wall1)
        {
            transform.position = new Vector3(-9.0159f, transform.position.y, 0f);
        }
        if (transform.position.x > wall2)
        {
            transform.position = new Vector3(9.0161f, transform.position.y, 0f);
        }
    }
}
