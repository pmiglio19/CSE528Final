using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.EntityMechanics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthUI : MonoBehaviour
    {
        private static int currentHealth = 10;
        public Text textHealth;

        void Start()
        {
            textHealth.text = currentHealth.ToString();
        }

        void Update()
        {
            textHealth.text = currentHealth.ToString();
        }

        public void IncrementHealth(int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, Health.GetMaxHealth());
        }

        public void DecrementHealth(int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, Health.GetMaxHealth());
        }

        public void ResetHealth()
        {
            currentHealth = 10;
        }
    }
}
