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
    public class WinnerText : MonoBehaviour
    {
        private GameObject playerGameObject;
        private PlayerController playerController;

        private void Update()
        {
            playerGameObject = GameObject.FindWithTag("Player");
            playerController = playerGameObject.GetComponent<PlayerController>();

            if (playerController.GetHasWon())
            {
                //GetComponent<Text>().gameObject.transform.position = new Vector3(0, 10, 0);
                //Debug.Log("SetActive true");
                //Debug.Log("Text: "+ GetComponent<Text>().text);

                GetComponent<Text>().enabled = true;

                Time.timeScale = 0;
            }
        }
    }
}
