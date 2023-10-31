using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbounds : MonoBehaviour
{
    public float wall1 = -6.9626f;
    public float wall2 = 6.9829f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < wall1)
        {
            transform.position = new Vector3(-6.9625f, transform.position.y, 0f);
        }
        if (transform.position.x > wall2)
        {
            transform.position = new Vector3(6.9830f, transform.position.y, 0f);
        }
    }
}
