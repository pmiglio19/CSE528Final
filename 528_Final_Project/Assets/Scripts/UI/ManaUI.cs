using Assets.Scripts.EntityMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ManaUI : MonoBehaviour
    {
        private static int currentMana = 12;

        public Text textMana;

        void Start()
        {
            textMana.text = currentMana.ToString();
        }

        void Update()
        {
            textMana.text = currentMana.ToString();
        }

        public void IncrementMana(int amount)
        {
            currentMana = Mathf.Clamp(currentMana + amount, 0, Mana.GetMaxMana());
        }                

        public void DecrementMana(int amount)
        {
            currentMana = Mathf.Clamp(currentMana - amount, 0, Mana.GetMaxMana());
        }

        public void ResetMana()
        {
            currentMana = 12;
        }
    }
}
