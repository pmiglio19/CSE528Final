using Assets.Scripts.EntityMechanics;
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
        Image spriteImage;
        Button button;
        Health health;

        private void Start()
        {
            spriteImage = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);

            health = new Health(10);
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

            return;
        }
    }
}
