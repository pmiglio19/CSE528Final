using UnityEngine.SceneManagement;
using UnityEngine;
using static Core.Simulation;
using Assets.Scripts.PlayerCharacter;
using Items;

namespace PlayerCharacter
{
    public class PlayerController : MonoBehaviour
    {
        #region Class Variables

        //Other states
        bool controlEnabled = true;
        bool spaceIsPressed = false;

        //Character states
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
        private SpriteRenderer spriteRenderer;
        internal Animator animator;

        //Other components
        private Collider2D collider2d;
        private Rigidbody2D rigidBody;

        //Character attributes
        private Health health;
        private Inventory inventory;
        private Mana mana;
        private Experience experience;

        #endregion

        private void Awake()
        {
            //To enable movement again after respawn
            controlEnabled = true;

            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider2d = GetComponent<Collider2D>();
            rigidBody = GetComponent<Rigidbody2D>();

            //Makes it so character's sprite doesn't roll around
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

            health = GetComponent<Health>();
            inventory = GetComponent<Inventory>();
            mana = GetComponent<Mana>();
            experience = GetComponent<Experience>();
        }

        //Apparently Update is used more specifically for key inputs
        private void Update()
        {
            //Check character health
            if(health.CheckForDeath())
            {
                RunDeathProtocols();
                RestartGame();

                //Ask to play again?
            }

            spaceIsPressed = Input.GetKeyDown(KeyCode.Space);
        }

        //And FixedUpdateis used more for things involving physics
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            //If character drops too far below viewable map, reset health and respawn
            if (transform.position.y < -10)
            {
                RunDeathProtocols();
                RestartGame();
            }

            if (controlEnabled)
            {
                #region Gather Movement Data
                //If character is grounded, get space key stroke
                if (isGrounded)
                {
                    isAscending = spaceIsPressed;
                }
                horizontalMovement = Input.GetAxis("Horizontal");

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
                    //Otherwise don't
                    else
                    {
                        direction = new Vector3(horizontalMovement, 0, 0);
                    }

                    //If he's about to ascend, play jump animation
                    if(isAscending)
                    {
                        animator.Play("MhumJump");
                    }

                    //This is the statement that actually moves the character
                    rigidBody.MovePosition(transform.position + direction * movementSpeedMultiplier * Time.fixedDeltaTime);

                    //Establish that the character is now descending (which will stop jump animation)
                    if(isAscending)
                    {
                        isAscending = false;
                        isDescending = true;
                        animator.SetBool("isDescending", isDescending);
                    }
                }
                //If character is not on ground and descending
                if (!isGrounded && isDescending)
                {
                    Vector3 direction = new Vector3(horizontalMovement, -1f, 0);

                    rigidBody.MovePosition(transform.position + direction * movementSpeedMultiplier * Time.fixedDeltaTime);
                }
                #endregion

                #region Check Orientation
                // Flipping character to left or right
                if (horizontalMovement > 0 && !facingRight)
                {
                    Flip();
                }
                else if (horizontalMovement < 0 && facingRight)
                {
                    Flip();
                }
                #endregion

                //Change animation to "walk" when moving and "idle" when not
                animator.SetFloat("Speed", Mathf.Abs(horizontalMovement) * movementSpeedMultiplier);
            }
        }

        #region Movement Utility
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

        private void FaceRight(GameObject gameObject)
        {
            if(gameObject.CompareTag("Player"))
            {
                if (!facingRight)
                {
                    facingRight = !facingRight;

                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    gameObject.transform.localScale = theScale;
                }
            }

            //else
            //{
            //    Vector3 theScale = transform.localScale;
            //    theScale.x *= -1;
            //    gameObject.transform.localScale = theScale;
            //}
        }

        private void FaceLeft(GameObject gameObject)
        {
            if (gameObject.CompareTag("Player"))
            {
                if (facingRight)
                {
                    facingRight = !facingRight;

                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    gameObject.transform.localScale = theScale;
                }
            }

            //else
            //{
            //    Vector3 theScale = transform.localScale;
            //    theScale.x *= -1;
            //    gameObject.transform.localScale = theScale;
            //}
        }


        #endregion

        #region Death and Game Restart
        private void RunDeathProtocols()
        {
            controlEnabled = false;
            animator.Play("MhumDeath");
            inventory.ClearInventory();
        }

        private void RestartGame()
        {
            health.ResetHealth();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion

        #region Collisions
        //Activates upon gameobject entering character's collider
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;

                //Debug.Log("In OnCollisionEnter2D");
                //Debug.Log("isGrounded is now " + isGrounded.ToString());
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                SceneManager.LoadScene("BattleScene");
                
                DontDestroyOnLoad(collider2d);
                DontDestroyOnLoad(collision.collider);

                //rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
                //rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                //collision.collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                //collision.collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                transform.position = new Vector3(-2f, 0f, 0f);
                collision.transform.position = new Vector3(2f, 0f, 0f);
                //FaceRight(transform.root.gameObject);
                //FaceLeft(collision.collider.gameObject);
            }

            if (collision.gameObject.CompareTag("Item"))
            {
                BaseItem item = new BaseItem(collision.gameObject.name);

                inventory.AddToInventory(item);
                inventory.PrintInventory();

                Destroy(collision.gameObject);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;

                //Debug.Log("In OnCollisionExit2D");
                //Debug.Log("isGrounded is now " + isGrounded.ToString());
            }
        }
        #endregion
    }
}