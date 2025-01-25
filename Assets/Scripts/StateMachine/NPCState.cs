using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* State for state machine for npcs
*/
public abstract class NPCState : ScriptableObject
{
    /**
    * Called before first update of state
    */
    public abstract void OnEnterState(GameObject gameObject);
    /**
    * Called every tick. Should return null if this action is to continue running, otherwise return the next state.
    *
    * If returning a new state to transition to, don't perform any redundant cleanup which will be performed in OnEndState
    */
    public abstract void UpdateState(float dt, StateMachineComponent stateMachine, GameObject gameObject);

    /**
    * Called after last UpdateState for any cleanup
    */
    public abstract void OnEndState(GameObject gameObject);
}
