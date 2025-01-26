using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum IDMatchType {
    INDIVIDUAL,
    CATEGORY,
    ALL
}

[System.Serializable]
public class NPCThoughtBubbleEffect {

    [SerializeField]
    [Tooltip("The type of id which the \"id\" field should match. Use this to select whether this NPCThoughtBubbleEffect is intended for an individual character, category of NPCs, or all NPCs.")]
    public IDMatchType idType; 

    [SerializeField]
    [Tooltip("ID used to match either to a specific NPC or category of NPCs. If ID Type is set to ALL, this value will be ignored")]
    public string id;

    [SerializeField]
    [Tooltip("The dialogue which this NPC should show while they have this thought bubble.")]
    public string dialogue;

    [SerializeField]
    [Tooltip("State which overrides the NPC's state while they have this thought bubble")]
    public NPCState npcStateOverride;
}



[CreateAssetMenu(menuName = "ThoughtBubble")]
public class ThoughtBubble : ScriptableObject
{
    [SerializeField]
    public string ThoughtBubbleName; 

    [SerializeField]
    [Tooltip("The effect a thought bubble should have on an NPC. Matching effect to NPC will go in order of the list, so INDIVIDUAL effects should be put before CATEGORY effects which should be before ALL effects.")]
    public NPCThoughtBubbleEffect[] effectOnNPC;


    [SerializeField]
    public Sprite thoughtBubbleIcon;


    public ThoughtBubble(){}

}
