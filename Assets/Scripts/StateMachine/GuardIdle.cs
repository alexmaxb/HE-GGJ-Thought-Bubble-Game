using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/GuardIdle")]
public class GuardIdle : NPCState
{
    public override void OnEndState(GameObject gameObject)
    {
        gameObject.GetComponent<Guard>().isAlert = false;
    }

    public override void OnEnterState(GameObject gameObject)
    {
        gameObject.GetComponent<Guard>().isAlert = true;
    }

    public override void UpdateState(float dt, StateMachineComponent stateMachine, GameObject gameObject)
    {
        
    }
}
