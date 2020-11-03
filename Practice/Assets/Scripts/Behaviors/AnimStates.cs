using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AnimStates : StateMachineBehaviour
{
    public UnityEvent stateEnterEvent, stateExitEvent;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateEnterEvent.Invoke();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateExitEvent.Invoke();
    }
}
