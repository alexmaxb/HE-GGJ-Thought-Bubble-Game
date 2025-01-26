using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/CheckForInventoryItem")]
public class CheckForInventoryItem : NPCState
{   
    public string requiredItem;
    public NPCState nextState;
    public override void OnEndState(GameObject gameObject)
    {
        if(gameObject.TryGetComponent<InteractableComponent>(out InteractableComponent interactable)) {
            interactable.OnInteract.RemoveListener(InteractableListener);
        }
    }

    public override void OnEnterState(GameObject gameObject)
    {
        Debug.Log("Entered CheckForInventoryItem state");
        if(gameObject.TryGetComponent<InteractableComponent>(out InteractableComponent interactable)) {
            interactable.OnInteract.AddListener(InteractableListener);
        }
    }

    public override void UpdateState(float dt, StateMachineComponent stateMachine, GameObject gameObject)
    {
        
    }

    public void InteractableListener(InteractableComponent interactable, GameObject other) {

        Debug.Log("Checking for item");

        if(other.TryGetComponent<ItemInventory>(out ItemInventory inventory)) {
            foreach(var item in inventory.currentInventory) {
                if(item.itemName == requiredItem) {
                    Debug.Log("Successfully found item!");

                    if(interactable.gameObject.TryGetComponent<StateMachineComponent>(out StateMachineComponent stateMachine)){
                        
                        stateMachine.TransitionState(nextState);
                    }
                }
            }
        }
    }

    
}
