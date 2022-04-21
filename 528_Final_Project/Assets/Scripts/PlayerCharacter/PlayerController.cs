using UnityEngine.SceneManagement;
using UnityEngine;
using static Core.Simulation;
using Assets.Scripts.EntityMechanics;
using Items;
using Assets.Scripts.EnemyCharacters;

namespace Assets.Scripts.PlayerCharacter
{
    public class PlayerController : MonoBehaviour
    {
        #region Class Variables

        //Control states
        bool controlEnabled = true;
        bool spaceIsPressed = false;
        bool tabIsPressed = false;

        //Character states
        bool isGrounded = false;
        bool isAscending = false;
        bool isDescending = true;
        bool isInvisible = false;
        bool swordIsEquipped = false;
        bool playerTurn = false;

        //Movement constants & variables
        const float movementSpeedMultiplier = .00001f;
        const float jumpHeightMultiplier = 7f;

        float horizontalMovement = 0;
        float verticalMovement = 0;
        bool facingRight = true;

        int invisoTimer = 0;
        int invisoTimerMax = 500;

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
        private DamageDealt damage;

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

            health = new Health(10);
            inventory = new Inventory();
            mana = new Mana(10);
            experience = new Experience();
            damage = new DamageDealt(1);     //Initially
        }

        //Apparently Update is used more specifically for key inputs
        private void Update()
        {
            //Check character health
            if (health.CheckForDeath())
            {
                RunDeathProtocols();
                //RestartGame();

                //Ask to play again?
            }

            spaceIsPressed = Input.GetKey(KeyCode.Space);
            tabIsPressed = Input.GetKey(KeyCode.Tab);
        }

        //And FixedUpdate is used more for things involving physics
        private void FixedUpdate()
        {
            if(tabIsPressed)
            {
                Attack();
            }

            InvisibleCheck();

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
                    rigidBody.AddForce(direction, ForceMode2D.Impulse);

                    Vector3 still = new Vector3(0.0000000001f, 00000000001f, 00000000001f);
                    rigidBody.AddForce(still);

                    //Establish that the character is now descending (which will stop jump animation)
                    if (isAscending)
                    {
                        isAscending = false;
                        isDescending = true;
                        animator.SetBool("isDescending", isDescending);
                    }
                }
                //If character is not on ground and descending
                if (!isGrounded && isDescending)
                {
                    Vector3 direction = new Vector3(horizontalMovement, 0, 0);
                    rigidBody.AddForce(direction, ForceMode2D.Impulse);

                    //rigidBody.MovePosition(transform.position + direction * movementSpeedMultiplier * Time.fixedDeltaTime);
                    Vector3 still = new Vector3(0.0000000001f, 00000000001f, 00000000001f);
                    rigidBody.AddForce(still);
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

        private void Attack()
        {
            //If swordIsEquipped and sword animator bool value is not set to true, do it
            //This will change Mhum's animation to carry a sword

        }

        private void InvisibleCheck()
        {
            if (isInvisible)
            {
                if (invisoTimer < invisoTimerMax)
                {
                    invisoTimer++;
                }
                else
                {
                    isInvisible = false;
                    invisoTimer = 0;
                    spriteRenderer.color += new Color(0, 0, 0, .5f);
                }
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
                if (isInvisible)
                {
                    Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
                }

                else
                {



                }
            }

            if (collision.gameObject.CompareTag("Item") || collision.gameObject.CompareTag("Weapon"))
            {
                BaseItem item = new BaseItem(collision.gameObject.GetComponent<BaseItem>().itemName, collision.gameObject.GetComponent<BaseItem>().damageMultiplier, collision.gameObject.GetComponent<BaseItem>().itemType,
                  collision.gameObject.GetComponent<BaseItem>().sprite);

                inventory.AddToInventory(item);

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

        #region Gets & Sets
        public Health GetPlayerHealth() { return health; }

        public Mana GetPlayerMana() { return mana; }

        public Inventory GetPlayerInventory() { return inventory; }

        public DamageDealt GetPlayerDamageDealt() { return damage; }

        public SpriteRenderer GetPlayerSpriteRenderer() { return spriteRenderer; }

        public bool GetPlayerTurn() { return playerTurn; }

        public void SetInvisibility(bool boolValue)
        {
            isInvisible = boolValue;
        }

        public void SetPlayerTurn(bool boolValue)
        {
            playerTurn = boolValue;
        }

        public void SetSwordIsEquipped(bool boolValue)
        {
            swordIsEquipped = boolValue;
        }
        #endregion
    }
}