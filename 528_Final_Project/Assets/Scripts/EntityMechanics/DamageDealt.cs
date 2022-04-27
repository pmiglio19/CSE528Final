using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EntityMechanics
{
    public class DamageDealt : MonoBehaviour 
    {
        private int damageMultiplier;
        private StrengthUI strengthUI;

        public DamageDealt(int _damageMultiplier)
        {
            damageMultiplier = _damageMultiplier;
            strengthUI = new StrengthUI();
        }

        public void ChangeMultiplier(int newMultiplier)
        {
            damageMultiplier = newMultiplier;
            strengthUI.IncrementStrength(1);
        }

        public int GetMultiplier()
        {
            return damageMultiplier;
        }

    }
}
