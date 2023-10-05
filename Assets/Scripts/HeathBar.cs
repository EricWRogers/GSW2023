using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Image sliderfill;
    public float maxHealth = 100;
    public float currentHealth;
    public float colorHue = 0.0f;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        currentHealth = maxHealth;

    }

    public void SetHealth(float health)
    {
        slider.value = health;
       
    }

    void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp((currentHealth - damage),0,maxHealth);

        slider.value = currentHealth;

        colorHue = ((currentHealth / 100) / 3) ; 

        sliderfill.color = Color.HSVToRGB(colorHue,1,1);

    }
       
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            Debug.Log("take damge");
        }
    }
}