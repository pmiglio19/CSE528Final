using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    
    //Used for any items that are one-time uses such as potions
    public class BaseConsumable : BaseItem
    {
        public BaseConsumable(string itemName, int damageMultiplier, string itemType, Sprite sprite) : base(itemName, damageMultiplier, itemType, sprite)
        {

        }
    }
}
