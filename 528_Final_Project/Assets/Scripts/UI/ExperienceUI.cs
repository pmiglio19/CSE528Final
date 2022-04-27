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
    public class ExperienceUI : MonoBehaviour
    {
        private static int currentXP = 1;
        public Text textXP;

        void Start()
        {
            textXP.text = currentXP.ToString();
        }

        void Update()
        {
            textXP.text = currentXP.ToString();
        }

        public void IncrementExperience(int amount)
        {
            currentXP = currentXP + amount;
        }

        public void DecrementExperience(int amount)
        {
            currentXP = currentXP - amount;
        }

        public void ResetExperience()
        {
            currentXP = 1;
        }
    }
}
