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

        public PlayerController playerController;
        public InventoryPanel inventoryPanel;
        public SkillsPanel skillsPanel;

        private Text text;
        private Health health;

        private void Start()
        {
            spriteImage = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);
            text = button.GetComponentInChildren<Text>();

            health = playerController.GetPlayerHealth();
        }

        private void TaskOnClick()
        {
            UseOption();
        }

        private void UseOption()
        {
            Debug.Log("Using option");
            Debug.Log("text: "+text.text);

            if (text.text == "Attack")
            {
                //Does attack animation and ~so much damage
                Debug.Log("Attack");
            }

            else if (text.text == "Magic")
            {
                Debug.Log("Magic");
                skillsPanel.gameObject.SetActive(true);
            }

            else if (text.text == "Items")
            {
                Debug.Log("Items");
                inventoryPanel.gameObject.SetActive(true);
            }

            else if (text.text == "Rest")
            {
                Debug.Log("Rest");
                health.IncrementByOne();
            }

            return;
        }
    }
}
