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
    public class BattleButton : MonoBehaviour
    {
        private Image spriteImage;
        private Button button;

        
        public InventoryPanel inventoryPanel;
        public SkillsPanel skillsPanel;

        private GameObject playerGameObject;
        private PlayerController playerController;
        private Text text;
        private Health health;

        private void Start()
        {
            playerGameObject = GameObject.FindWithTag("Player");

            spriteImage = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);
            text = button.GetComponentInChildren<Text>();

            playerController = playerGameObject.GetComponent<PlayerController>();
            health = playerController.GetPlayerHealth();
        }

        void OnMouseOver()
        {
            //If your mouse hovers over the GameObject with the script attached, output this message
            Debug.Log("Mouse is over GameObject.");
        }

        private void TaskOnClick()
        {
            UseOption();
        }

        private void UseOption()
        {
            if (text.text == "Attack")
            {
                //Does attack animation and ~so much damage
            }

            else if (text.text == "Magic")
            {
                skillsPanel.gameObject.SetActive(true);
            }

            else if (text.text == "Items")
            {
                inventoryPanel.gameObject.SetActive(true);
            }

            else if (text.text == "Rest")
            {
                health.IncrementByOne();
            }

            return;
        }
    }
}
