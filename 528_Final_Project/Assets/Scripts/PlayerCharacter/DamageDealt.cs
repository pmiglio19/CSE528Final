using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerCharacter
{
    public class DamageDealt : MonoBehaviour 
    {
        private int damageMultiplier;

        public DamageDealt(int _damageMultiplier)
        {
            damageMultiplier = _damageMultiplier;
        }

        public void ChangeMultiplier(int newMultiplier)
        {
            damageMultiplier = newMultiplier;
            Debug.Log("Damage multiplier is now: " + damageMultiplier.ToString());
        }

    }
}
