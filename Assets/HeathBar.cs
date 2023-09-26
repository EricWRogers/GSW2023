using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public float maxHealth = 100;
    public float currentHealth;

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
        currentHealth -= damage;

       slider.value = currentHealth;

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