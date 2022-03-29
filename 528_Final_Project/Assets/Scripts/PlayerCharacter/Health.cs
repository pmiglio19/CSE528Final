using System;
//using Platformer.Gameplay;
using UnityEngine;
using static Core.Simulation;

namespace PlayerCharacter
{
    public class Health : MonoBehaviour
    {
        public int maxHP = 10;

        public bool IsAlive => currentHP > 0 ? true : false;

        public int currentHP;

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

        void Awake()
        {
            currentHP = maxHP;
        }
    }
}
