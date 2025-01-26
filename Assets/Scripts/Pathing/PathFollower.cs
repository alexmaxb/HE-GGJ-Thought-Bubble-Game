using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum EFollowPathState {
    DISABLED,
    ENABLED,
    COMPLETE,
}
public class PathFollower : MonoBehaviour
{
    public EFollowPathState followPath = EFollowPathState.DISABLED;

    public Path currentPath;

    public float speed = 5;

    public float waypointProximityThreshold = .1f;

    private int progress = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(followPath == EFollowPathState.ENABLED && currentPath != null && progress < currentPath.WayPoints.Length) {
            if(Vector2.Distance(transform.position, currentPath.WayPoints[progress].transform.position) < waypointProximityThreshold) {
                progress++;
            }

            if(progress >= currentPath.WayPoints.Length) {
                followPath = EFollowPathState.COMPLETE;
            }
            else {
                GameObject waypoint = currentPath.WayPoints[progress];
                Vector3 diffPos = waypoint.transform.position - transform.position;
                Vector3 step = diffPos.normalized * speed * Time.deltaTime;
                if(step.magnitude > diffPos.magnitude) {
                    step = diffPos;
                }

                transform.position = transform.position + step;
            }
        }
    }

    public void StartPathFromBeginning(Path p) {
        currentPath = p;
        progress = 0;
        followPath = EFollowPathState.ENABLED;
    }

    public void ResumeIfPossible(Path p) {
        if(currentPath != null &&
        followPath != EFollowPathState.ENABLED &&
        p.key == currentPath.key) {
            followPath = EFollowPathState.ENABLED;
        }
        else StartPathFromBeginning(p);
    }
}
