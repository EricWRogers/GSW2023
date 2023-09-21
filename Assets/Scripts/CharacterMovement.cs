using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SuperPupSystems.GamePlay2D;

public class CharacterMovement : CharacterControllerXA
{
        public CharacterControllerXA controller;
        public float speed = 10.0f;
        public float collisionTestOffset;

        float horizontalMove = 0.0f;
        public bool crouch;
        bool jump;

        public SpriteRenderer spriteRenderer;
        public Animator animator;

        private Rigidbody2D _rb2d;
        
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
            if (Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") >= 0.5f )
            {
                jump = true;
            }

            if (Input.GetAxisRaw("Vertical") <= -0.5f)
            {
                crouch = true;
            }
            // float xInput = Input.GetAxis("Horizontal");
            // // /*isTouchingGround = IsTouchingGround();*/
            // Vector2 motion = _rb2d.velocity;

            // if (xInput != 0.0f)
            // {
                
            //     if (/*!TestMove(Vector2.right, collisionTestOffset) && */xInput > 0.0f)
            //     {
            //         motion.x = xInput * (speed*0.1f);
            //     }
            //     else if (/*!TestMove(Vector2.left, collisionTestOffset) && */xInput < 0.0f)
            //     {
            //         motion.x = xInput * (speed*0.1f);
            //     }
            //     else
            //     {
            //         motion.x = -xInput * speed;
            //     }
            // }

            // if (Input.GetAxis("Jump") > 0 && /*isTouchingGround*/grounded)
            // {
            //     motion.y = jumpForce+2.5f;
            // }

            // if (animator != null)
            // {
            //     animator.SetFloat("SpeedX", Mathf.Abs(motion.x));
            //     animator.SetFloat("SpeedY", motion.y);
            //     animator.SetBool("Grounded", /*isTouchingGround*/grounded);
            // }

            // if (spriteRenderer != null && xInput != 0.0f)
            // {
            //     if (xInput > 0.0f)
            //         spriteRenderer.flipX = false;
            //     else
            //         spriteRenderer.flipX = true;
            // }

            // _rb2d.velocity = motion;
        }

        void FixedUpdate()
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
            crouch = false;
        }

}