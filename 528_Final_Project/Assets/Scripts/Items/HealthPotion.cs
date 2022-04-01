using Assets.Scripts.EntityMechanics;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Items
{
    //Increases health by 5
    public class HealthPotion : BaseConsumable
    {
        public HealthPotion(string itemName, int damageMultiplier, string itemType) : base(itemName, damageMultiplier, itemType)
        {

        }

        public void IncreaseHealth(Health health)
        {
            health.IncrementByAmount(5);
        }

    }
}
