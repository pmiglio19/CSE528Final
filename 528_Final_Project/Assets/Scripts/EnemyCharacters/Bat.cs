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
    class Bat : BaseEnemy
    {
        private float min = 2f;
        private float max = 3f;
        public float maxDistanceCovered = 0f;
        private bool facingRight;
        private bool isFlipped;

        private GameObject playerGameObject;
        private PlayerController playerController;

        public Bat(int _maxDistanceCovered) : base()
        {
            maxDistanceCovered = _maxDistanceCovered;
        }

        private void Awake()
        {
            health = new EnemyHealth(2);
            experienceGained = 4;
            min = transform.position.x;
            max = transform.position.x + maxDistanceCovered;
            damage = new DamageDealt(2);
            facingRight = true;
            isFlipped = true;
        }

        private void Update()
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

            if (transform.position.x < max && transform.position.x >= max - .4f && isFlipped)
            {
                Flip();
                isFlipped = !isFlipped;
            }

            else if (transform.position.x > min && transform.position.x <= min + .4f && !isFlipped)
            {
                Flip();
                isFlipped = !isFlipped;
            }
        }

        private void FixedUpdate()
        {
            if (health.CheckForDeath())
            {
                playerGameObject = GameObject.FindWithTag("Player");
                playerController = playerGameObject.GetComponent<PlayerController>();

                playerController.GetPlayerExperience().IncrementExperience(experienceGained, playerController.GetPlayerDamageDealt());

                Destroy(gameObject);
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
