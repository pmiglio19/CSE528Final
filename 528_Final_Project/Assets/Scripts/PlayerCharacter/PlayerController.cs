using UnityEngine.SceneManagement;
using UnityEngine;
using static Core.Simulation;

namespace PlayerCharacter
{
    public class PlayerController : MonoBehaviour
    {
        #region Class Variables
        //public AudioClip jumpAudio;
        //public AudioClip respawnAudio;
        //public AudioClip ouchAudio;

        //readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        //public Bounds Bounds => collider2d.bounds;


        //Character states
        bool controlEnabled = true;
        bool isGrounded = false;
        bool isAscending = false;
        bool isDescending = true;

        //Movement constants & variables
        const float movementSpeedMultiplier = 5f;
        const float jumpHeightMultiplier = 20f;

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
        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider2d = GetComponent<Collider2D>();
            rigidBody = GetComponent<Rigidbody2D>();
            //audioSource = GetComponent<AudioSource>();

            health = GetComponent<Health>();
        }

        private void Update()
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
                #region Gather Movement Data
                //If character is grounded, get space key stroke
                if (isGrounded)
                {
                    horizontalMovement = Input.GetAxis("Horizontal");

                    isAscending = Input.GetKeyDown(KeyCode.Space);
                }
                else if (!isGrounded)
                {
                    horizontalMovement = Input.GetAxis("Horizontal");
                }
                #endregion

                #region Move Character
                //Checks if character is on ground and about to ascend             
                if (isGrounded)
                {
                    Vector3 direction = new Vector3();

                    //If in air, include vertical movement
                    if(isAscending)
                    {
                        direction = new Vector3(horizontalMovement, jumpHeightMultiplier, 0);
                    }
                    else
                    {
                        direction = new Vector3(horizontalMovement, 0, 0);
                    }

                    if(isAscending)
                    {
                        animator.Play("MhumJump");
                    }

                    rigidBody.MovePosition(transform.position + direction * movementSpeedMultiplier * Time.fixedDeltaTime);

                    isAscending = false;
                    isDescending = true;
                }
                //If character is not on ground and descending
                if (!isGrounded && isDescending)
                {
                    animator.Play("MhumIdle");

                    Vector3 direction = new Vector3(horizontalMovement, -1f, 0);

                    rigidBody.MovePosition(transform.position + direction * movementSpeedMultiplier * Time.fixedDeltaTime);

                    //animator.SetBool("isAscending", isAscending);
                }
                #endregion

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

        #region Collisions
        //Activates upon gameobject entering character's collider
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                //isDescending = false;
                //isAscending = false;
                Debug.Log("In OnCollisionEnter2D");
                Debug.Log("isGrounded is now " + isGrounded.ToString());
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
                isAscending = false;
                Debug.Log("In OnCollisionExit2D");
                Debug.Log("isGrounded is now " + isGrounded.ToString());
            }
        }
        #endregion
    }
}