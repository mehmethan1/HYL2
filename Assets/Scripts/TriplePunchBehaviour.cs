using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriplePunchBehaviour : StateMachineBehaviour
{
    [SerializeField] Boss Boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.TriplePunch();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.GetPosition = false;
        Boss.CanChoose = true;
    }
}
