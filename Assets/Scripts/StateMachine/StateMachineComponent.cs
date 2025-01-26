using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineComponent : MonoBehaviour
{

    [SerializeField]
    private NPCState currentState;


    // Start is called before the first frame update
    void Start()
    {
        currentState.OnEnterState(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(Time.deltaTime, this, this.gameObject);
    }


    public void TransitionState(NPCState state) {
        currentState.OnEndState(this.gameObject);
        state.OnEnterState(this.gameObject);

        currentState = state;
    }

    public NPCState GetState() {
        return currentState;
    }
}
