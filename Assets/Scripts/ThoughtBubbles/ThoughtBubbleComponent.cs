using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
* Component for NPCs which have a thought bubble 
*/
[RequireComponent(typeof(InteractableComponent))]
[RequireComponent(typeof(StateMachineComponent))]
[RequireComponent(typeof(NPC))]
public class ThoughtBubbleComponent : MonoBehaviour
{
    [SerializeField]
    private ThoughtBubble currentThoughtBubble;

    private bool stateMachineOverride = false;
    private NPCState overriddenState;

    private ShowWhenPlayerNearby showWhenPlayerNearby;

    void Awake() {
        showWhenPlayerNearby = GetComponentInChildren<ShowWhenPlayerNearby>();
        
    }

    void Start()
    {
        //GetComponent<InteractableComponent>().OnInteract.AddListener(OnInteract);

        ActivateBubbleEffects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnInteract(GameObject player) {
        ThoughtBubbleInventory playerBubbleInventory = player.GetComponent<ThoughtBubbleInventory>();

        if (playerBubbleInventory != null) {
            this.currentThoughtBubble = playerBubbleInventory.SwapBubble(currentThoughtBubble);

            if(stateMachineOverride) {
                // revert to previous state

                stateMachineOverride = false;
                GetComponent<StateMachineComponent>().TransitionState(overriddenState);

                GetComponent<NPC>().ResetDialogue();
                

            }

            ActivateBubbleEffects();
        }
    }

    private void ActivateBubbleEffects() {

        NPC npc = GetComponent<NPC>();

        if(currentThoughtBubble == null) {Debug.LogError("ThoughtBubbleComponent for npc " + npc.name + "doesn't have a thought bubble"); return;}

        if(currentThoughtBubble.thoughtBubbleIcon != null) {
            showWhenPlayerNearby.OnSwitchBubbleIcon(currentThoughtBubble.thoughtBubbleIcon);
        }

        foreach(var effect in currentThoughtBubble.effectOnNPC) {
            // check if the filter matches this npc
            if((effect.idType == IDMatchType.INDIVIDUAL && effect.id == npc.id) ||
            (effect.idType == IDMatchType.CATEGORY && effect.id == npc.category) ||
            (effect.idType == IDMatchType.ALL)) {

                Debug.Log("Thought bubble has effect for this npc" );
                // Apply effect

                // if this effect overrides the state of the NPC, save the current state and transition to the override state.
                if(effect.npcStateOverride != null) {

                    StateMachineComponent stateMachine = GetComponent<StateMachineComponent>();
                    stateMachineOverride = true;
                    overriddenState = stateMachine.GetState();

                    stateMachine.TransitionState(effect.npcStateOverride);
                }

                // TODO : Dialogue

                npc.SetCurrentDialogue(effect.dialogue);


                break;
            }
        }
    }
}
