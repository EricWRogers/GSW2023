using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperPupSystems.Helper;

public class Charge : MonoBehaviour
{
    public CharacterControllerXA characterControllerXA;
    public HealthBar playerDamage;
    public float multiplier = 0.0f;
    public float startCharge = 50.0f;
    public float charge;
    public float startCR = 0.0f;
    public float chargeRate;
    public float delay = 2.0f;
    float tempTime;
    private SpriteRenderer sprite;
    Color playerColor;
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

    void chargeBurst(){
        float burst = 25.0f;
        if(Input.GetKeyDown(KeyCode.Space) && charge > 0){
            SetCharge(charge - burst); 
            
        }
        
    }

    void chargeBump() {
        float bump = 10.0f;
        if (Input.GetKeyDown(KeyCode.Z)) {
            SetCharge(charge + bump);
        }
    }

    public void attackChargeDamage()
    {
        if (charge > 0 && charge <= 25)
        {
            multiplier = 0.5f;
        }
        if (charge >= 26 && charge <= 50)
        {
            multiplier = 1f;
        }
        if (charge >= 51 && charge <= 75)
        {
            multiplier = 1.5f;
        }
        if (charge >= 76 && charge <= 99)
        {
            multiplier = 2f;
        }
        if (charge == 100)
        {
            multiplier = 3f;
        }
    }

    void Update(){
        tempTime +=Time.deltaTime;
        
        if(Input.GetButtonDown(gameObject.GetComponent<CharacterMovement>().playerNum+" Vertical")){
            timer.StartTimer();

        }

        SetCharge(charge);
        attackChargeDamage();
        CrouchCharge();
        //Invoke("CrouchCharge", 3.0f);
        
        chargeBurst();
        chargeBump();
        if(chargeRate > 0){
            sprite.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        }

    }
}


