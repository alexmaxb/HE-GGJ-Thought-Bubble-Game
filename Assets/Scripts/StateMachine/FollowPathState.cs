using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/FollowPathState")]
public class FollowPathState : NPCState
{

    public string PathID;

    public override void OnEndState(GameObject gameObject)
    {
        // Disable path follow component
        if(gameObject.TryGetComponent<PathFollower>(out PathFollower follower)) {
            follower.followPath = EFollowPathState.DISABLED;
        }
    }

    public override void OnEnterState(GameObject gameObject)
    {
        //enable path follow component
        Path p = FindObjectOfType<PathLibrary>().GetPathByKey(PathID);
        if(p!=null && gameObject.TryGetComponent<PathFollower>(out PathFollower follower)) {
            follower.ResumeIfPossible(p);
        }
    }

    public override void UpdateState(float dt, StateMachineComponent stateMachine, GameObject gameObject)
    {
        
    }
}
