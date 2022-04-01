using System;
using UnityEngine;
using static Core.Simulation;

namespace Assets.Scripts.EntityMechanics
{
    public class Health : MonoBehaviour
    {
        private int maxHP;

        private int currentHP;

        public Health(int _maxHP)
        {
            maxHP = _maxHP;
            currentHP = maxHP;
        }

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
