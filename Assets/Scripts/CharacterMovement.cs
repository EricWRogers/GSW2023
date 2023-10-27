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
        public string playerNum;

        float horizontalMove = 0.0f;
        public bool crouch;
        bool jump;

        public bool punch;
        public bool kick;
        public bool block;

        public SpriteRenderer spriteRenderer;

        private Rigidbody2D _rb2d;
        
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            horizontalMove = Input.GetAxisRaw(playerNum+" Horizontal") * speed;
            if (Input.GetButtonDown(playerNum+" Jump"))
            {
                jump = true;

            }

            if (Input.GetAxisRaw(playerNum+" Vertical") <= -0.5f)
            {
                crouch = true;
            }

            if (Input.GetButtonDown(playerNum+" Button 1"))
            {
                punch = true;
                playerCharge.charge -= 5.0f;
            }

            if (Input.GetButtonDown(playerNum+" Button 2"))
            {
                kick = true;
                playerCharge.charge -= 5.0f;
            }

            if (Input.GetAxisRaw(playerNum+" Button 3") > 0.1)
            {
                block = true;
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
            if (Input.GetAxisRaw(playerNum+" Vertical") <= -0.5f)
            {
                crouch = true;
            }
            
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, punch, kick, block);
            jump = false;
            crouch = false;
            punch = false;
            kick = false;
            block = false;
        }

}