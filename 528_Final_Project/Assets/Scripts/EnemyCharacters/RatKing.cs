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
    public class RatKing : BaseEnemy
    {
        float maxMoveDistance = .5f;
        bool facingRight = false;
        float speed = 5;

        private GameObject playerGameObject;
        private PlayerController playerController;

        public RatKing() : base()
        {
            health = new EnemyHealth(15);
            experienceGained = 12;
            damage = new DamageDealt(5);
        }

        private void Update()
        {
            Vector3 destination = transform.position;

            if (facingRight)
            {
                destination.x = (transform.position.x + .5f);
            }
            else
            {
                destination.x = (transform.position.x - .5f);
            }

            destination.y = (transform.position.y > transform.position.y + maxMoveDistance) ? transform.position.y : transform.position.y + maxMoveDistance;
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (health.CheckForDeath())
            {
                playerGameObject = GameObject.FindWithTag("Player");
                playerController = playerGameObject.GetComponent<PlayerController>();

                playerController.GetPlayerExperience().IncrementExperience(experienceGained, playerController.GetPlayerDamageDealt());

                Destroy(gameObject);

                playerController.SetHasWon(true);

                Debug.Log("Player has won: " + playerController.GetHasWon());
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Wall"))
            {
                Flip();
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
