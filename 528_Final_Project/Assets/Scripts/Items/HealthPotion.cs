using Assets.Scripts.EntityMechanics;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    //Increases health by 5
    public class HealthPotion : BaseConsumable
    {
        //public Sprite newSprite;

        public HealthPotion(string itemName, int damageMultiplier, string itemType, Sprite sprite) : base(itemName, damageMultiplier, itemType, sprite)
        {
            //sprite = newSprite;
        }

        private void Awake()
        {
            //Debug.Log("Health potion renderer name: " + sRenderer.name);
        }

        public void IncreaseHealth(Health health)
        {
            health.IncrementByAmount(5);
        }

    }
}
