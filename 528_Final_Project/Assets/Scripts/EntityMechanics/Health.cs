using Assets.Scripts.UI;
using System;
using UnityEngine;
using static Core.Simulation;

namespace Assets.Scripts.EntityMechanics
{
    public class Health : MonoBehaviour
    {
        private static int maxHP;
        private static int currentHP;
        private HealthUI healthUI;

        public Health(int _maxHP)
        {
            maxHP = _maxHP;
            currentHP = maxHP;
            healthUI = new HealthUI();
        }

        public void IncrementByOne()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
            healthUI.IncrementHealth(1);
        }

        public void IncrementByAmount(int amount)
        {
            currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
            healthUI.IncrementHealth(amount);
        }

        public void DecrementByOne()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);

            healthUI.DecrementHealth(1);
        }

        public void DecrementByAmount(int amount)
        {
            currentHP = Mathf.Clamp(currentHP - amount, 0, maxHP);

            healthUI.DecrementHealth(amount);
        }

        public void Die()
        {
            while (currentHP > 0) DecrementByOne();
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

        public static int GetMaxHealth() { return maxHP; }

        public int GetCurrentHealth() { return currentHP; }
    }
}
