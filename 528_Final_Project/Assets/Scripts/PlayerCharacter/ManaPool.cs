﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerCharacter
{
    public class ManaPool : MonoBehaviour
    {
        private int manaLevel;

        public ManaPool()
        {
            manaLevel = 20;
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
