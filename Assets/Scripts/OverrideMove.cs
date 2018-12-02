using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideMove : StateMachineBehaviour {
 	public Creature.State state;
	 override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		  animator.GetComponent<Creature>().state = state;
    }

//    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//		animator.GetComponent<Creature>().moveControl = 1f;
//    }

/*   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
*/
}
