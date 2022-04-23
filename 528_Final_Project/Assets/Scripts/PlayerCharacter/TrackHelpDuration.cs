using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlayerCharacter
{
    public class TrackHelpDuration : StateMachineBehaviour
    {
        private GameObject playerGameObject;
        private PlayerController playerController;

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            playerGameObject = GameObject.FindWithTag("Player");
            playerController = playerGameObject.GetComponent<PlayerController>();

            BoxCollider2D collider = playerController.GetComponent<BoxCollider2D>();

            collider.size = new Vector2(collider.size.x-1f, collider.size.y);

            animator.SetBool("isAttacking", false);
            playerController.SetIsAttacking(false);
        }
    }
}
