using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


/**
* Component for the player to track the thought bubble they are currently holding
*/
public class ThoughtBubbleInventory : MonoBehaviour
{
    [SerializeField]
    private ThoughtBubble currentThoughtBubble;


    
    /**
    * Event when a new thought bubble is picked up.
    */
    [SerializeField]
    public UnityEvent<ThoughtBubble> OnNewThoughtBubble = new UnityEvent<ThoughtBubble>();

    public ThoughtBubble SwapBubble(ThoughtBubble bubble) {
        Debug.Log("Player swapped bubble with NPC: Gave NPC " + currentThoughtBubble.ThoughtBubbleName + " and received " + bubble.ThoughtBubbleName);

        ThoughtBubble temp = currentThoughtBubble;
        currentThoughtBubble = bubble;

        OnNewThoughtBubble.Invoke(bubble);

        return temp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
