using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.EntityMechanics
{
    public class Inventory : MonoBehaviour
    {
        private List<BaseItem> items;
        private InventoryPanel inventoryPanel;

        public Inventory()
        {
            items = new List<BaseItem>();
            inventoryPanel = new InventoryPanel();
        }

        public void AddToInventory(BaseItem item)
        {
            items.Add(item);
            inventoryPanel.AddToInventoryPanel(item.GetSprite());
        }

        public void RemoveFromInventory(string itemName)
        {
            foreach(BaseItem item in items)
            {
                if (item.itemName == itemName)
                {
                    items.Remove(item);
                    return;
                }
            }
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
                Debug.Log("Item "+ i.ToString()+": "+ item.itemName);
                Debug.Log("Item sprite" + i.ToString() + ": " + item.GetSprite().name);
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
