using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class BaseWeapon : BaseItem
    {
        public BaseWeapon(string itemName, int damageMultiplier, string itemType, Sprite sprite) : base(itemName, damageMultiplier, itemType, sprite)
        {

        }

    }
}
