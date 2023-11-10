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

    public float knockbackNumber = 5.0f;
    [SerializeField] private float damageNumber = 0.0f;

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
                Vector2 direction = (collision.transform.position - transform.position).normalized;
                Vector2 knockback = direction * knockbackNumber;
                Debug.Log(knockback);
                targetPlayer._rb2d.AddForce(knockback, ForceMode2D.Impulse);
                Debug.Log("is Hit");
                playerHealth.TakeDamage(damageNumber * playerCharge.chargeMultiplier);
                Debug.Log("Damage Number" + damageNumber * playerCharge.chargeMultiplier);
                Debug.Log("Charge Multiplier" + playerCharge.chargeMultiplier);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
