using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStun : MonoBehaviour
{
    public CharacterMovement movement;
    public bool isStun = false;
    public bool gotHit = false;
    public float timeStunned = 1.0f;
    private float timeStun;
    
    // Start is called before the first frame update
    void Start()
    {
        timeStun = timeStunned;
    }

    // Update is called once per frame
    void Update()
    {
        if(gotHit)
        {
            if(timeStun <= 0)
            {
                isStun = false;
                gotHit = false;
                timeStun = timeStunned;
            } else
            {
                isStun = true;
                timeStun -= Time.deltaTime;
                movement.horizontalMove = 0;
                movement.kick = false;
                movement.punch = false;
                movement.block = false;
                Debug.Log(timeStun - Time.deltaTime);
            }
        }
    }
}
