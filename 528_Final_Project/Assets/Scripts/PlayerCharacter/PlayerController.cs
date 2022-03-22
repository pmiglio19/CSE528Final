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


        //Character states
        bool controlEnabled = true;
        bool isJumping = false;
        bool isGrounded = true;

        //Movement constants & variables
        const float movementSpeedMultiplier = 5;
        const float jumpHeightMultiplier = 40;

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

        //Character attributes
        public Health health;


        void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider2d = GetComponent<Collider2D>();
            rigidBody = GetComponent<Rigidbody2D>();
            //audioSource = GetComponent<AudioSource>();

            health = GetComponent<Health>();
        }

        protected override void Update()
        {
            //Check character health
            if(health.currentHP <= 0)
            {
                //Play death animation
                //Ask to play again?
            }

            //Move character
            Move();
        }


        private void Move()
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
                if (isJumping)
                {
                    //animator.SetBool("isGrounded", isGrounded);
                    animator.SetBool("isJumping", isJumping);
                    verticalMovement = Time.deltaTime * jumpHeightMultiplier;

                    //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 20, transform.position.z), verticalMovement * 0.5f);
                    transform.Translate(0, verticalMovement, 0);

                    isGrounded = false;
                }

                //If character is on ground, move horizontal                
                if (isGrounded)
                {
                    horizontalMovement = Input.GetAxis("Horizontal");
                    horizontalMovement *= Time.deltaTime * movementSpeedMultiplier;
                    transform.Translate(horizontalMovement, 0, 0);
                }
                //If character is in air, move horizontal AND descend
                else if (!isGrounded)
                {
                    horizontalMovement = Input.GetAxis("Horizontal");
                    horizontalMovement *= Time.deltaTime * movementSpeedMultiplier;
                    transform.Translate(horizontalMovement, -1f * Time.deltaTime, 0);
                }

                // Flipping character to left or right
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
            animator.SetBool("isJumping", isJumping);
            //animator.SetBool("isGrounded", isGrounded);
        }

        //Used to flip character left or right
        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        //Activates upon gameobject entering character's collider
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
    }
}