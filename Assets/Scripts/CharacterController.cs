using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 50f;

    [Range(0, 1)] [SerializeField] private float crouchSpeed = 0.5f;

    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private bool airControl = true;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private Transform celingCheck;

    [SerializeField] private Collider2D crouchDisableCollider;

    const float groundedRadius = .2f;
    public bool grounded;
    const float cellingRadius = .2f;
    private Rigidbody2D rigidbody2D;
    private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> {}

    public BoolEvent OnCrouchEvent;
    private bool wasCrouching = false;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }

        if(OnCrouchEvent == null)
        {
            OnCrouchEvent = new BoolEvent();
        }
    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (crouch)
        {
            if (Physics2D.OverlapCircle(celingCheck.position, cellingRadius, whatIsGround))
            {
                crouch = true;
            }
        }
        
        if (grounded || airControl)
        {
            if (crouch)
            {
                if (!wasCrouching)
                {
                    wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                move *= crouchSpeed;

                if(crouchDisableCollider != null)
                {
                    crouchDisableCollider.enabled = true;
                }

                if (wasCrouching)
                {
                    wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);

            rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

            if (move > 0 && !facingRight)
            {
                Flip();
            }

            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }

        if (grounded && jump)
        {
            grounded = false;
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
