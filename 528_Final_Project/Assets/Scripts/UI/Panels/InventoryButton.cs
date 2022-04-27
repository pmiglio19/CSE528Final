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

        private GameObject playerGameObject;
        private PlayerController playerController;

        public InventoryPanel inventoryPanel;
        private Health health;
        private Inventory inventory;
        private DamageDealt damage;

        private void Start()
        {
            spriteImage = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);

            playerGameObject = GameObject.FindWithTag("Player");
            playerController = playerGameObject.GetComponent<PlayerController>();

            health = playerController.GetPlayerHealth();
            inventory = playerController.GetPlayerInventory();
            damage = playerController.GetPlayerDamageDealt();
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
                playerController.SetInvisibility(true);

                List<GameObject> listOfEnemies = playerController.GetListOfEnemies();
                listOfEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

                foreach(GameObject enemy in listOfEnemies)
                {
                    Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), playerController.GetComponent<Collider2D>(), true);
                }

                playerController.GetPlayerSpriteRenderer().color += new Color(0, 0, 0, -.5f);
            }

            else if (spriteImage.sprite.name == "Sword")
            {
                damage.ChangeMultiplier(2);
                playerController.SetSwordIsEquipped(true);
            }

            inventory.RemoveFromInventory(spriteImage.sprite.name);
            inventoryPanel.RemoveFromInventoryPanel(spriteImage.sprite.name);

            return;
        }
    }
}
