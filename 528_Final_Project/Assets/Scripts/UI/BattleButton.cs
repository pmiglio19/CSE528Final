﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class BattleButton : MonoBehaviour
    {
        private Image spriteImage;
        private Button button;
        //public PlayerController playerController;
        public InventoryPanel inventoryPanel;
        //private Health health;
        //private Inventory inventory;
        //private DamageDealt damage;

        private void Start()
        {
            spriteImage = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);

            //health = playerController.GetPlayerHealth();
            //inventory = playerController.GetPlayerInventory();
            //damage = playerController.GetPlayerDamageDealt();
        }

        private void TaskOnClick()
        {
            UseOption();
        }

        private void UseOption()
        {
            //if (spriteImage.sprite.name == "UISprite")
            //{
            //    return;
            //}

            //else if (spriteImage.sprite.name == "HealthPotion")
            //{
            //    health.IncrementByAmount(5);
            //}

            //else if (spriteImage.sprite.name == "InvisibilityPotion")
            //{
            //    playerController.SetInvisibility(true);
            //    playerController.GetPlayerSpriteRenderer().color += new Color(0, 0, 0, -.5f);
            //}

            //else if (spriteImage.sprite.name == "Sword")
            //{
            //    damage.ChangeMultiplier(2);
            //    playerController.SetSwordIsEquipped(true);
            //}

            //inventory.RemoveFromInventory(spriteImage.sprite.name);
            //inventoryPanel.RemoveFromInventoryPanel(spriteImage.sprite.name);

            return;
        }
    }
}
