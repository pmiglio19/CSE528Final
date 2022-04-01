using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerCharacter
{
    public class Inventory : MonoBehaviour
    {
        List<BaseItem> items;

        public Inventory()
        {
            items = new List<BaseItem>();
        }

        public void AddToInventory(BaseItem item)
        {
            items.Add(item);
        }

        public void RemoveFromInventory(BaseItem item)
        {
            items.Remove(item);
        }

        public void ClearInventory()
        {
            items.Clear();
        }

        //For utility only
        public void PrintInventory()
        {
            int i = 1;
            foreach (BaseItem item in items)
            {
                Debug.Log("Got right here");
                Debug.Log("Item "+ i.ToString()+": "+ item.itemName);
                i++;
            }
        }

        public int CheckInventoryForWeapons()
        {
            int damageMultiplier = 1;

            //Need to find a better system for having multiple different weapons, but this is just a demo
            foreach (BaseItem item in items)
            {
                if(item.itemType == "Weapon")
                {
                    damageMultiplier = item.damageMultiplier;
                }
            }

            return damageMultiplier;
        }
    }
}
