using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/TestState")]
public class TestState : NPCState
{

    public string TestTag = "";
    
    public bool printOnEnter = true;
    public bool printOnExit = true;
    public bool printOnUpdate = false;


    public override void OnEndState(GameObject gameObject)
    {
        if(printOnExit)
            Debug.Log("NPC " + gameObject.GetComponent<NPC>().id + " has exited test state: " + TestTag);
    }

    public override void OnEnterState(GameObject gameObject)
    {
        if(printOnEnter)
            Debug.Log("NPC " + gameObject.GetComponent<NPC>().id + " has entered test state: " + TestTag);
    }

    public override void UpdateState(float dt, StateMachineComponent stateMachine, GameObject gameObject)
    {
        if(printOnUpdate)
            Debug.Log("NPC " + gameObject.GetComponent<NPC>().id + " has updated test state: " + TestTag);
    }
}
