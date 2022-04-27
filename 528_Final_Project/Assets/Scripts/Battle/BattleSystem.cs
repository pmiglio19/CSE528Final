using Assets.Scripts.EnemyCharacters;
using Assets.Scripts.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Battle
{
    public class BattleSystem : MonoBehaviour
    {
        private GameObject playerGameObject;
        private PlayerController playerController;

        private GameObject enemyGameObject;
        private BaseEnemy enemyController;

        public Button quitButton;

        private void Awake()
        {
            playerGameObject = GameObject.FindWithTag("Player");
            playerController = playerGameObject.GetComponent<PlayerController>();

            enemyGameObject = GameObject.FindWithTag("Enemy");
            enemyController = enemyGameObject.GetComponent<BaseEnemy>();
        }

        private void Update()
        {
            ////Player turn
            //while(playerController.GetPlayerTurn())
            //{
            //    continue;
            //}

            ////Enemy turn
            //if(!playerController.GetPlayerTurn())
            //{
            //    //Move enemy around

            //    enemyController.Attack();

            //    playerController.SetPlayerTurn(true);
            //}

            if(enemyController.GetEnemyHealth().CheckForDeath())
            {
                SceneManager.LoadScene("OverworldScene");
            }

            if(playerController.GetPlayerHealth().CheckForDeath())
            {
                quitButton.gameObject.SetActive(true);
            }
        }

    }
}
