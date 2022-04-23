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
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("isAttacking", false);
            //animator.Play("MhumIdle");
        }
    }
}
