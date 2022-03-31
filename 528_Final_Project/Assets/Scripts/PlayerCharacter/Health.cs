using System;
//using Platformer.Gameplay;
using UnityEngine;
using static Core.Simulation;

namespace PlayerCharacter
{
    public class Health : MonoBehaviour
    {
        private const int maxHP = 10;

        //private bool IsAlive => currentHP > 0 ? true : false;

        private int currentHP;

        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
        }

        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        public void ResetHealth()
        {
            currentHP = maxHP;
        }

        public bool CheckForDeath()
        {
            if(currentHP <= 0)
            {
                return true;
            }

            return false;
        }

        void Awake()
        {
            currentHP = maxHP;
        }
    }
}
