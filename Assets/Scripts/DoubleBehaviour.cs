using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBehaviour : StateMachineBehaviour
{
    [SerializeField] Boss Boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.DoublePunch();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss.GetPosition = false;
        Boss.CanChoose = true;
    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

}
