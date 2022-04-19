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
    public class SkillsButton : MonoBehaviour
    {
        private Image spriteImage;
        private Button button;

        private GameObject playerGameObject;
        private PlayerController playerController;
        public SkillsPanel skillsPanel;
        private Mana mana;
        private DamageDealt damage;

        private void Start()
        {
            spriteImage = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);

            playerGameObject = GameObject.FindWithTag("Player");
            playerController = playerGameObject.GetComponent<PlayerController>();

            mana = playerController.GetPlayerMana();
            damage = playerController.GetPlayerDamageDealt();
        }

        private void TaskOnClick()
        {
            UseSkill();
        }

        private void UseSkill()
        {
            if (spriteImage.sprite.name == "Zappy")
            {
                //Do zappy thing
            }

            skillsPanel.gameObject.SetActive(false);

            return;
        }
    }
}
