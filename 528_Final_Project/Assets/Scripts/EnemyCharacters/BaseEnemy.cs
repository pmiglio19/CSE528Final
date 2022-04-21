using Assets.Scripts.EntityMechanics;
using Assets.Scripts.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EnemyCharacters
{
    public class BaseEnemy : MonoBehaviour
    {
        //Stats
        protected EnemyHealth health;
        protected DamageDealt damage;
        protected int experienceGained;

        //Animations
        SpriteRenderer spriteRenderer;
        internal Animator animator;

        //Other components
        protected Collider2D collider2d;
        protected Rigidbody2D rigidBody;

        protected bool isInBattle = false;
        
        private GameObject playerGameObject;
        private PlayerController playerController;

        private void Awake()
        {
            playerGameObject = GameObject.FindWithTag("Player");
            playerController = playerGameObject.GetComponent<PlayerController>();

            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider2d = GetComponent<Collider2D>();
            rigidBody = GetComponent<Rigidbody2D>();

            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //private void FixedUpdate()
        //{
        //    if (health.CheckForDeath())
        //    {
        //        Destroy(gameObject);
        //    }
        //}

        public EnemyHealth GetEnemyHealth()
        {
            return health;
        }

        public DamageDealt GetEnemyDamageDealt()
        {
            return damage;
        }

        public void SetIsInBattle(bool newBool)
        {
            isInBattle = newBool;
        }

        public void Attack()
        {
            playerController.GetPlayerHealth().DecrementByAmount(damage.GetMultiplier());
        }
    }
}
