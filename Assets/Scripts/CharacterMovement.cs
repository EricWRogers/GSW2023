using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SuperPupSystems.GamePlay2D;
using SuperPupSystems.Helper;

public class CharacterMovement : CharacterControllerXA
{
        public CharacterControllerXA controller;
        public float speed = 10.0f;
        public float collisionTestOffset;
        public string playerNum;
        public Charge playerCharge;
        public float spendCharge = 5.0f;
        public float horizontalMove = 0.0f;
        public bool crouch;
        bool jump;
        public bool freeze;

        public bool punch;
        public bool kick;
        public bool block;

        //public Timer timer;
        public bool gotHit = false;

        public SpriteRenderer spriteRenderer;

        public Rigidbody2D _rb2d;
        
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            
            horizontalMove = (Mathf.Clamp((Input.GetAxis(playerNum+" Horizontal") + Input.GetAxis(playerNum+" Horizontal Axis")),-1,1)) * speed * playerCharge.speedMultiplier; // bad hack but it works well enough
            //horizontalMove = Input.GetAxis(playerNum+" Horizontal Axis") * speed * playerCharge.speedMultiplier;
            if (Input.GetButtonDown(playerNum+" Jump") || Input.GetAxis(playerNum+ " Vertical") >= 0.5f | Input.GetAxis(playerNum+ " Vertical Axis") >= 0.5f)
            {
                jump = true;
            }

            if (Input.GetAxis(playerNum+" Vertical") <= -0.5f || Input.GetAxis(playerNum+ " Vertical Axis") <= -0.5f)
            {
                crouch = true;
            }

            if (Input.GetButtonDown(playerNum+" Punch"))
            {
                
                punch = true;
                
                playerCharge.charge -= spendCharge;
            }

            if (Input.GetButtonDown(playerNum+" Kick"))
            {
                kick = true;
                playerCharge.charge -= spendCharge;
            }

            if (Input.GetAxisRaw(playerNum+" Block") > 0.1)
            {
                block = true;
            }
            // float xInput = Input.GetAxis("Horizontal");
            // /*isTouchingGround = IsTouchingGround();*/
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
            if (gotHit)
            {
                horizontalMove = 0;
                kick = false;
                punch = false;
                block = false;
            }
            if (freeze == true)
            {
            horizontalMove = 0;
           
            jump = false;
        }
            
           
            
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

        public void StunnedisOver()
        {
            gotHit = false;
        }

}