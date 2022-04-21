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
        private bool facingRight;
        private bool isFlipped;

        public Bat(int _maxDistanceCovered) : base()
        {
            health = new EnemyHealth(3);
            experienceGained = 4;

            maxDistanceCovered = _maxDistanceCovered;
            isFlipped = true;
        }

        private void Awake()
        {
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
                Debug.Log("max");
                Flip();
                isFlipped = !isFlipped;
            }

            else if (transform.position.x > min && transform.position.x <= min + .4f && !isFlipped)
            {
                Debug.Log("min");
                Flip();
                isFlipped = !isFlipped;
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
