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

        public Mana(int _manaLevel)
        {
            manaLevel = _manaLevel;
        }

        public void IncrementMana(int amount)
        {
            manaLevel += amount;
        }

        public void DecrementMana(int amount)
        {
            manaLevel -= amount;
        }

    }
}
