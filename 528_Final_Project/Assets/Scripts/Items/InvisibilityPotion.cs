using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Items
{
    public class InvisibilityPotion : BaseConsumable
    {
        public InvisibilityPotion(string itemName, int damageMultiplier, string itemType) : base(itemName, damageMultiplier, itemType)
        {

        }

        public void TurnInvisible()
        {
            //...
        }
    }
}
