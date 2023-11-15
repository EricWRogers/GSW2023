using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterControllerXA : MonoBehaviour
{
    [SerializeField] private float jumpForce = 50f;

    [Range(0, 1)] [SerializeField] private float crouchSpeed = 0.5f;

    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private bool airControl = true;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private Transform celingCheck;

    //[SerializeField] private Collider2D crouchDisableCollider;

    const float groundedRadius = .2f;
    public bool grounded;
    public bool fastFall;
    public float fastFallSpeed = 6.0f;
    public float fallSpeed = 1.0f;
    public float movementAction = 1.0f;
    const float cellingRadius = .2f;
    public Rigidbody2D rb2D;
    private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;
    private Vector2 motion = Vector2.zero;
    public Animator animator;
    public GameObject target;
    //public GameObject playerText;
    public float airSpeed = 0.335f;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> {}

    public BoolEvent OnCrouchEvent;
    public bool crouching;
    private bool wasCrouching = false;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>(); 

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

    public void Move(float move, bool crouch, bool jump, bool punch, bool kick, bool block)
    {
        if (crouch)
        {
            if (Physics2D.OverlapCircle(celingCheck.position, cellingRadius, whatIsGround))
            {
                crouching = true;
            }
            if (grounded)
            {
                crouching = true;
                fastFall = false;
            }
            else
            {
                crouching = false;
                fastFall = true;
            }
        }
        else
        {
            crouching = false;
            fastFall = false;
        }

        if(fastFall)
        {
            rb2D.gravityScale = fastFallSpeed;
        }
        else
        {
            rb2D.gravityScale = fallSpeed;
        }
        
        if (grounded || airControl)
        {
            if (crouching)
            {
                if (!wasCrouching)
                {
                    wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }


                //if(crouchDisableCollider != null)
                //{
                //    crouchDisableCollider.enabled = true;
                //}

                if (wasCrouching)
                {
                    wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            if(crouching || ((kick || punch) && grounded))
            {
                move *= crouchSpeed;
            }

            if (!grounded)
            {
                block = false;
                move *= airSpeed;
            }

            if (block)
            {
               move = 0;
            }

            Vector3 targetVelocity = new Vector2(move * 10f, rb2D.velocity.y);

            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetVelocity, ref velocity, movementSmoothing);

             if (gameObject.GetComponent<Transform>().position.x < target.GetComponent<Transform>().position.x && !facingRight)
            {
                Flip();
                //playerText.transform.localScale *= 1;
             }

             else if (gameObject.GetComponent<Transform>().position.x > target.GetComponent<Transform>().position.x && facingRight)
            {
                Flip();
                //playerText.transform.localScale *= 1;
            }
        }

        if (grounded && jump)
        {
            motion = rb2D.velocity;
            grounded = false;
            motion.y = jumpForce;
            rb2D.velocity = motion;
        }

        motion = rb2D.velocity;
        if(animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(motion.x));
            //animator.SetFloat("Speedy", Abs(motion.y));
            animator.SetBool("Grounded", grounded);
            animator.SetBool("Crouching", crouching);
            animator.SetBool("Punch", punch);
            animator.SetBool("Kick", kick);
            animator.SetBool("Block", block);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        //playerText.transform.localScale *= 1;
    }
}
