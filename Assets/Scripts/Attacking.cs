using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;


public class Attacking : MonoBehaviour
{
    public AudioSource audioPlayer;
    public HealthBar playerHealth;
    public Charge playerCharge;
    public CharacterMovement targetPlayer;

    public Timer timer;

    private CharacterMovement hitCol;
    public GameObject hitCollider;


    public float knockbackNumber = 5.0f;
    public float damageNumber = 0.0f;
    public float hitStunDuration;

    void Awake()
    {
        hitCol = hitCollider.GetComponent<CharacterMovement>();
    }
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit " + collision.gameObject.name);
        hitCol = collision.gameObject.GetComponentInParent<CharacterMovement>();
        if (collision.gameObject.CompareTag("HurtCollider"))
        {
                audioPlayer.Play();
            if (hitCol.playerNum == targetPlayer.playerNum)
            {
                Vector2 direction = (collision.transform.position - transform.position).normalized;
                Vector2 knockback = direction * knockbackNumber;
                targetPlayer._rb2d.AddForce(knockback, ForceMode2D.Impulse);
                //targetPlayer.PlayIframe();
                playerHealth.TakeDamage(damageNumber * playerCharge.chargeMultiplier);
                targetPlayer.gotHit = true;
                timer.StartTimer(hitStunDuration);
                //Debug.Log("Start Time");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
