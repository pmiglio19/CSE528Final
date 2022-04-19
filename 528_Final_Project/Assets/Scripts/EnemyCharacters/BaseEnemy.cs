﻿using Assets.Scripts.EntityMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EnemyCharacters
{
    class BaseEnemy : MonoBehaviour
    {
        //Stats
        protected Health health;
        protected DamageDealt damage;
        protected int experienceGained;

        //Animations
        SpriteRenderer spriteRenderer;
        internal Animator animator;

        //Other components
        public Collider2D collider2d;
        public Rigidbody2D rigidBody;

        protected bool isInBattle = false;

        public BaseEnemy()
        {

        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            collider2d = GetComponent<Collider2D>();
            rigidBody = GetComponent<Rigidbody2D>();

            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public void SetIsInBattle(bool newBool)
        {
            isInBattle = newBool;
        }
    }
}
