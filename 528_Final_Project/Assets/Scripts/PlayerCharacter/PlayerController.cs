using UnityEngine.SceneManagement;
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

        //readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        //public Bounds Bounds => collider2d.bounds;


        //Character attributes
        public Health health;
        bool controlEnabled = true;
        bool isJumping = false;

        //Movement constants & variables
        const float movementSpeedMultiplier = 5;
        const float jumpHeightMultiplier = 10;

        float horizontalMovement = 0;
        float verticalMovement = 0;
        bool facingRight = true;

        //Animations
        SpriteRenderer spriteRenderer;
        internal Animator animator;

        //Other components
        public Collider2D collider2d;
        public Rigidbody2D rigidBody;
        //public AudioSource audioSource;

        void Awake()
        {
            health = GetComponent<Health>();
            //audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody2D>();
        }

        protected override void Update()
        {
            //If character drops too far below viewable map, reset health and respawn
            if (transform.position.y < -10)
            {
                health.currentHP = health.maxHP; 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (controlEnabled)
            {
                //Check if character is jumping
                if (!isJumping)
                {
                    isJumping = Input.GetKeyDown(KeyCode.Space);
                }

                //If character is beginning to jump, move him upward and start jumping animation
                if(isJumping)
                {
                    animator.SetBool("isJumping", true);
                    verticalMovement = Time.deltaTime * jumpHeightMultiplier;
                    transform.Translate(0, verticalMovement, 0);
                }

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
            }

            isJumping = false;
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
    }
}