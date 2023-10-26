using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Attacking : MonoBehaviour
{
    public HealthBar playerHealth;
    public Charge playerCharge;
    public CharacterMovement targetPlayer;
    private CharacterMovement hitCol;
    public GameObject hitCollider;

    public float damageNumber = 0.0f;
    //public float chargeDischarge = 0.0f;

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
            if (hitCol.playerNum == targetPlayer.playerNum)
            {
                Debug.Log("is Hit");
                Debug.Log(playerCharge.multiplier);
                playerHealth.TakeDamage(damageNumber * playerCharge.multiplier);
                Debug.Log("Damage is : " + damageNumber * playerCharge.multiplier);
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
