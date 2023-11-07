using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attacking : MonoBehaviour
{
    public HealthBar playerHealth;
    public CharacterMovement targetPlayer;
    private CharacterMovement hitCol;
    public GameObject hitCollider;

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
                Debug.Log("is Hit");
                playerHealth.TakeDamage(damageNumber);
                this.GetComponentInParent<SoundBehaviour>().OnHit();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
