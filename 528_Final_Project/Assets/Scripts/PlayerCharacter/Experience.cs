using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerCharacter
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
            nextExperienceLevelGoal = 100;
        }

        public void IncrementExperience(int amount)
        {
            experienceAmount += amount;
            CheckIfLevelUp(experienceAmount);
        }

        private void CheckIfLevelUp(int xpAmount)
        {
            if(xpAmount >= nextExperienceLevelGoal)
            {
                experienceLevel += 1;
                nextExperienceLevelGoal += 1000;
            }
        }
    }
}
