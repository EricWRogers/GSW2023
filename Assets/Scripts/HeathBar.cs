using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Image sliderfill;
    public float maxHealth = 100;
    public float currentHealth;
    public float colorHue = 0.0f;

    public float timeForDamage = 2.0f;
    public float amountOfDamage = 12.5f;
    public float counter = 0.0f;

    [System.Serializable]
    public class DamageSnapShot
    {
        public float pointInTime;
        public float damageTaken;
    }

    public List<DamageSnapShot> damageTaken = new List<DamageSnapShot>();

    private CharacterMovement iframe;

    private void Start()
    {
        SetMaxHealth(maxHealth);
        colorHue = ((currentHealth / 100) / 3);
        sliderfill.color = Color.HSVToRGB(colorHue, 1, 1);

        iframe = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        counter += Time.deltaTime;

        if (GetTotalDamage() >= amountOfDamage)
        {
            iframe.PlayIframe();
            damageTaken.Clear();
        }

        if (iframe.punch == true || iframe.kick == true)
        {
            iframe.StopIframe();
        }
    }

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

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp((currentHealth - damage),0,maxHealth);

        slider.value = currentHealth;

        colorHue = ((currentHealth / 100) / 3) ; 

        sliderfill.color = Color.HSVToRGB(colorHue,1,1);
        if (currentHealth == 0.0f)
        {
            Debug.Log("Dead");
            //SceneManager.LoadSceneAsync("XanderTestScene");
        }

        DamageSnapShot dss = new DamageSnapShot();
        dss.damageTaken = damage;
        dss.pointInTime = counter;
        damageTaken.Add(dss);
    }

    private float GetTotalDamage()
    {
        float totalDamage = 0;

        for (int i = 0; i < damageTaken.Count;)
        {
            if (timeForDamage < counter - damageTaken[i].pointInTime)
            {
                damageTaken.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        foreach (DamageSnapShot ds in damageTaken)
        {
            totalDamage += ds.damageTaken;
        }
        return totalDamage;
    }

    /*public void DamageThreshold()
    {
        float preHealth = currentHealth;

        if (timeLeftDuration <= 0)
        {
            if (preHealth - currentHealth >= damageThreshold)
            {
                iframe.PlayIframe();
                Debug.Log("Iframe has Started");
            }
            else
            {
                ResetTime();
                Debug.Log("Damage Threshold was not reached");
            }
        }
    }*/
}
