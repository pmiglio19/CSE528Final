using Assets.Scripts.EntityMechanics;
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
        public bool facingRight = true;
        private bool justStarted;

        public Bat(int _maxDistanceCovered, bool _facingRight) : base()
        {
            health = new EnemyHealth(3);
            experienceGained = 4;
            damage = new DamageDealt(2);

            maxDistanceCovered = _maxDistanceCovered;
            facingRight = _facingRight;
            justStarted = true;
        }

        private void Awake()
        {
            min = transform.position.x;
            max = transform.position.x + maxDistanceCovered;
            justStarted = true;
        }

        private void Update()
        {
            if (!isInBattle)
            {
                transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

                if (transform.position.x == max)
                {
                    Debug.Log("max");
                    Flip();
                    justStarted = false;
                }

                if (!justStarted && transform.position.x == min)
                {
                    Debug.Log("min");
                    Flip();
                }
            }
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
