using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EntityMechanics
{
    public class Experience : MonoBehaviour
    {
        private int experienceAmount;
        private int experienceLevel;
        private int nextExperienceLevelGoal;

        public Experience()
        {
            experienceAmount = 0;
            experienceLevel = 1;
            nextExperienceLevelGoal = 10;
        }

        public void IncrementExperience(int amount, DamageDealt damage)
        {
            experienceAmount += amount;
            CheckIfLevelUp(experienceAmount, damage);
        }

        private void CheckIfLevelUp(int xpAmount, DamageDealt damage)
        {
            if(xpAmount >= nextExperienceLevelGoal)
            {
                experienceLevel += 1;
                nextExperienceLevelGoal += 10;

                damage.ChangeMultiplier(damage.GetMultiplier() + 1);
            }
        }
    }
}
