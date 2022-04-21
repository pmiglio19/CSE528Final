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
        
        private void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider2d = GetComponent<Collider2D>();
            rigidBody = GetComponent<Rigidbody2D>();

            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Skill"))
            {
                health.DecrementByAmount(10);
            }
        }
    }
}
