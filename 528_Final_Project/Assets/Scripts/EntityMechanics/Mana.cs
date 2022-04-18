using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EntityMechanics
{
    public class Mana : MonoBehaviour
    {
        private int manaLevel;
        private static int maxMana;
        private ManaUI manaUI;

        public Mana(int _manaLevel)
        {
            manaLevel = _manaLevel;
            manaUI = new ManaUI();
            maxMana = 10;
        }

        public void IncrementMana(int amount)
        {
            manaLevel = Mathf.Clamp(manaLevel + amount, 0, maxMana);
            manaUI.IncrementMana(amount);
        }

        public void DecrementMana(int amount)
        {
            manaLevel = Mathf.Clamp(manaLevel - amount, 0, maxMana);
            manaUI.DecrementMana(amount);
        }

        public static int GetMaxMana() { return maxMana; }
    }
}
