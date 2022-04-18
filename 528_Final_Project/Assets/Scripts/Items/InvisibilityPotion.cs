using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class InvisibilityPotion : BaseConsumable
    {
        public InvisibilityPotion(string itemName, int damageMultiplier, string itemType, Sprite sprite) : base(itemName, damageMultiplier, itemType, sprite)
        {

        }

        public void TurnInvisible()
        {
            //...
        }
    }
}
