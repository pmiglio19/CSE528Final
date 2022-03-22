using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Physics;             
using static Core.Simulation;

namespace PlayerCharacter
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        //public AudioClip jumpAudio;
        //public AudioClip respawnAudio;
        //public AudioClip ouchAudio;

        ///// <summary>
        ///// Max horizontal speed of the player.
        ///// </summary>
        //public float maxSpeed = 7;
        ///// <summary>
        ///// Initial jump velocity at the start of a jump.
        ///// </summary>
        //public float jumpTakeOffSpeed = 7;
        //bool jump;

        //public JumpState jumpState = JumpState.Grounded;
        //private bool stopJump;
        

        //readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        //public Bounds Bounds => collider2d.bounds;




        //Character attributes
        public Health health;
        public bool controlEnabled = true;

        //Movement constants & variables
        const float movementSpeedMultiplier = 5;

        float horizontalMovement = 0;
        float verticalMovement = 0;
        bool facingRight = true;

        //Animations
        SpriteRenderer spriteRenderer;
        internal Animator animator;

        //Other components
        public Collider2D collider2d;
        //public AudioSource audioSource;

        void Awake()
        {
            health = GetComponent<Health>();
            //audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                horizontalMovement = Input.GetAxis("Horizontal");
                horizontalMovement *= Time.deltaTime * movementSpeedMultiplier;
                transform.Translate(horizontalMovement, 0, 0);

                if (horizontalMovement > 0 && !facingRight)
                {
                    Flip();
                }
                else if (horizontalMovement < 0 && facingRight)
                {
                    Flip();
                }

                //Change animation to "walk" when moving and "idle" when not
                animator.SetFloat("Speed", Mathf.Abs(horizontalMovement) * movementSpeedMultiplier);

                //if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                //    jumpState = JumpState.PrepareToJump;
                //else if (Input.GetButtonUp("Jump"))
                //{
                //    stopJump = true;
                //    Schedule<PlayerStopJump>().player = this;
                //}
            }
            //else
            //{
            //    move.x = 0;
            //}
            //UpdateJumpState();
            //base.Update();
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        //void UpdateJumpState()
        //{
        //    jump = false;
        //    switch (jumpState)
        //    {
        //        case JumpState.PrepareToJump:
        //            jumpState = JumpState.Jumping;
        //            jump = true;
        //            stopJump = false;
        //            break;
        //        case JumpState.Jumping:
        //            if (!IsGrounded)
        //            {
        //                Schedule<PlayerJumped>().player = this;
        //                jumpState = JumpState.InFlight;
        //            }
        //            break;
        //        case JumpState.InFlight:
        //            if (IsGrounded)
        //            {
        //                Schedule<PlayerLanded>().player = this;
        //                jumpState = JumpState.Landed;
        //            }
        //            break;
        //        case JumpState.Landed:
        //            jumpState = JumpState.Grounded;
        //            break;
        //    }
        //}

        //protected override void ComputeVelocity()
        //{
        //    if (jump && IsGrounded)
        //    {
        //        velocity.y = jumpTakeOffSpeed * model.jumpModifier;
        //        jump = false;
        //    }
        //    else if (stopJump)
        //    {
        //        stopJump = false;
        //        if (velocity.y > 0)
        //        {
        //            velocity.y = velocity.y * model.jumpDeceleration;
        //        }
        //    }

        //    if (move.x > 0.01f)
        //        spriteRenderer.flipX = false;
        //    else if (move.x < -0.01f)
        //        spriteRenderer.flipX = true;

        //    animator.SetBool("grounded", IsGrounded);
        //    animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        //    targetVelocity = move * maxSpeed;
        //}

        //public enum JumpState
        //{
        //    Grounded,
        //    PrepareToJump,
        //    Jumping,
        //    InFlight,
        //    Landed
        //}
    }
}