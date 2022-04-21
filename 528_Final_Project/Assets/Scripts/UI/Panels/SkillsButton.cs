using Assets.Scripts.EnemyCharacters;
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
        private Text text;

        private GameObject playerGameObject;
        private PlayerController playerController;
        private GameObject enemyGameObject;
        private BaseEnemy enemyController;
        private GameObject skillObject;

        public SkillsPanel skillsPanel;
        private Mana mana;
        private DamageDealt damage;

        private void Start()
        {
            spriteImage = GetComponent<Image>();
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);
            text = button.GetComponentInChildren<Text>();

            playerGameObject = GameObject.FindWithTag("Player");
            playerController = playerGameObject.GetComponent<PlayerController>();

            skillObject = GameObject.FindWithTag("Skill");

            mana = playerController.GetPlayerMana();
            damage = playerController.GetPlayerDamageDealt();
        }

        private void TaskOnClick()
        {
            UseSkill();
        }

        private void UseSkill()
        {
            if (mana.GetManaLevel() >= 5 && text.text == "Zappy")
            {
                Vector3 newLightningPosition;

                if(playerController.GetFacingRight())
                {
                    newLightningPosition = new Vector3(playerController.transform.position.x + 3, playerController.transform.position.y, 0);
                }

                else
                {
                    newLightningPosition = new Vector3(playerController.transform.position.x - 3, playerController.transform.position.y, 0);
                }

                skillObject.transform.position = newLightningPosition;

                skillObject.GetComponent<Animator>().Play("Lightning", -1, 0f);
                
                mana.DecrementMana(5);
            }

            return;
        }
    }
}
