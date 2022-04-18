using Assets.Scripts.EntityMechanics;
using Assets.Scripts.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class InventoryButton : MonoBehaviour
    {
        private Image spriteImage;
        private Button button;
        public PlayerController playerController;
        public InventoryPanel inventoryPanel;
        private Health health;
        private Inventory inventory;

        private void Start()
        {
            spriteImage = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);

            health = playerController.GetPlayerHealth();
            inventory = playerController.GetPlayerInventory();
        }

        private void TaskOnClick()
        {
            UseItem();
        }

        private void UseItem()
        {
            if (spriteImage.sprite.name == "UISprite")
            {
                return;
            }

            else if (spriteImage.sprite.name == "HealthPotion")
            {
                health.IncrementByAmount(5);
            }

            else if (spriteImage.sprite.name == "InvisibilityPotion")
            {

            }

            else if (spriteImage.sprite.name == "Sword")
            {

            }

            inventory.RemoveFromInventory(spriteImage.sprite.name);
            inventoryPanel.RemoveFromInventoryPanel(spriteImage.sprite.name);

            return;
        }
    }
}
