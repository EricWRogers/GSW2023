using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperPupSystems.Helper;

public class Charge : MonoBehaviour
{
    public CharacterControllerXA characterControllerXA;
    public float startCharge = 50.0f; 
    public float charge;
    public float startCR = 0.0f;
    public float chargeRate;
    public float delay = 2.0f;
    public float chargeMultiplier = 0.0f;
    float tempTime;
    private SpriteRenderer sprite;
    //Color playerColor;
    public Slider slider;
    public Timer timer;
    bool delayFinish = false;
    
    void SetCharge(float _value)
    {
        charge = Mathf.Clamp(_value, 0, 100);
        slider.value = _value;
    }

    void Start(){
        SetCharge(startCharge);
        chargeRate = startCR; 
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void DelayOver(){
        delayFinish = true;
    }

    public void CrouchCharge(){
        //Calls function every decimal value of a second

        if(delayFinish == false){
            return;
        }
        
        if(tempTime > 0.1){
            tempTime = 0;
            SetCharge(charge + chargeRate);
                
            if(characterControllerXA.crouching && charge < 100.0f ){
                chargeRate = 1.0f;
            }
            else{
                chargeRate = 0.0f;
                delayFinish = false;
            }
        }
    }   
    public void AttackingChargeMutiplier()
    {
        if (charge > 0 && charge < 26)
        {
            chargeMultiplier = 0.5f;
        }

        if(charge > 25 &&  charge < 51)
        {
            chargeMultiplier = 1.0f;
        }
        if (charge > 50 && charge < 76)
        {
            chargeMultiplier = 1.5f;
        }
        if (charge > 75 && charge < 99)
        {
            chargeMultiplier = 2.0f;
        }
        if (charge == 100)
        {
            chargeMultiplier = 3.0f;
        }
    }
    void chargeBurst(){
        float burst = 25.0f;
        if(Input.GetKeyDown(KeyCode.Space) && charge > 0){
            SetCharge(charge - burst); 
            
        }
        
    }

    void chargeBump(){
        float bump = 10.0f;
        if(Input.GetKeyDown(KeyCode.Z)){
            SetCharge(charge + bump);
        }
    }
    

    void Update(){
        tempTime +=Time.deltaTime;
        
        if(Input.GetButtonDown(gameObject.GetComponent<CharacterMovement>().playerNum+" Vertical")){
            timer.StartTimer();

        }

        AttackingChargeMutiplier();
        CrouchCharge();
        //Invoke("CrouchCharge", 3.0f);
        SetCharge(charge);
        //chargeBurst();
        //chargeBump();
        //if(chargeRate > 0){
            //sprite.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        //}

    }
}


