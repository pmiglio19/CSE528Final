using Assets.Scripts.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class QuitButton : MonoBehaviour
    {
        private Button button;
        public InventoryPanel inventoryPanel;

        private GameObject playerGameObject;
        private PlayerController playerController;

        private GameObject canvas;
        private HealthUI healthText;
        private ManaUI manaText;
        private StrengthUI strengthText;
        private ExperienceUI experienceText;

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);

            playerGameObject = GameObject.FindWithTag("Player");
            playerController = playerGameObject.GetComponent<PlayerController>();

            canvas = GameObject.FindWithTag("Canvas");
            healthText = canvas.GetComponent<HealthUI>();
            manaText = canvas.GetComponent<ManaUI>();
            strengthText = canvas.GetComponent<StrengthUI>();
            experienceText = canvas.GetComponent<ExperienceUI>();
        }

        private void TaskOnClick()
        {
            Time.timeScale = 1;
            playerController.GetPlayerHealth().ResetHealth();
            playerController.GetPlayerMana().ResetMana();
            healthText.ResetHealth();
            manaText.ResetMana();
            strengthText.ResetStrength();
            experienceText.ResetExperience();
            SceneManager.LoadScene("TitleScene");
            Time.timeScale = 1;

        }
    }
}
