﻿using Assets.Scripts.EntityMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EnemyCharacters
{
    class Slime : BaseEnemy
    {
        float maxMoveDistance = .5f;
        //Set this to your objects initial position when game starts.
        Vector3 origin;
        float speed = 5;

        public Slime() : base()
        {
            health = new EnemyHealth(5);
            experienceGained = 3;
            damage = new DamageDealt(3);
        }

        private void Update()
        {
            if(!isInBattle)
            {
                Vector3 destination = transform.position;
                destination.y = (transform.position.y > origin.y + maxMoveDistance) ? origin.y : origin.y + maxMoveDistance;
                transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            }
        }
    }
}
