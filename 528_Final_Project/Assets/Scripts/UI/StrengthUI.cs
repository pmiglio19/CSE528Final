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
    public class StrengthUI : MonoBehaviour
    {
        private static int currentStrength = 1;
        public Text textStrength;

        void Start()
        {
            textStrength.text = currentStrength.ToString();
        }

        void Update()
        {
            textStrength.text = currentStrength.ToString();
        }

        public void IncrementStrength(int amount)
        {
            currentStrength = currentStrength + amount;
        }

        public void DecrementStrength(int amount)
        {
            currentStrength = currentStrength - amount;
        }

        public void ResetStrength()
        {
            currentStrength = 1;
        }
    }
}
