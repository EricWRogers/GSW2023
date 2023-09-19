using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public float startCharge = 50.0f; 
    public float charge;
    public float startCR = 0.0f;
    public float chargeRate;
    public bool isCharging;
    float tempTime;
    private SpriteRenderer sprite;
    Color playerColor;
    

    void Start(){
        charge = startCharge;
        chargeRate = startCR; 
        isCharging = false;
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void crouchCharge(){
        //Calls function every decimal value of a second
            if(tempTime > 0.1){
                tempTime = 0;
                charge += chargeRate;
                //When Arrow Down is held Charge Rate is activated as long as charge is less than 100
                if(Input.GetKey(KeyCode.DownArrow) && charge < 100.0f){
                chargeRate = 1.0f;
                }
            else{
                chargeRate = 0.0f;
            }
        }
    }   

    void chargeBurst(){
        float burst = 25.0f;
        if(Input.GetKeyDown(KeyCode.Space) && burst <= (0+charge)){
            charge -= burst; 
            
        }
        
    }

    void chargeBump(){
        float bump = 10.0f;
        if(Input.GetKeyDown(KeyCode.Z) && bump < (100.0f-charge)){
            charge += bump;
        }
        if(Input.GetKeyDown(KeyCode.Z) &&89.9f < charge && charge < 100.0f){
            charge = 100.0f;
        }
    }
    

    void Update(){
        tempTime +=Time.deltaTime;
        
        crouchCharge();
        chargeBurst();
        chargeBump();
        sprite.color = new Color(1.0f, ((100-charge)/100), ((100-charge)/100), 1.0f);
    }
}


