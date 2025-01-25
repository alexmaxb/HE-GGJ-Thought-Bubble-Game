using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/GiveItemFromInventory")]
public class GiveItemFromInventory : NPCState
{


    public void OnInteract(InteractableComponent interactable, GameObject gameObject) {
       if(interactable.TryGetComponent<ItemInventory>(out ItemInventory NPCInventory) && 
       gameObject.TryGetComponent<ItemInventory>(out ItemInventory playerInventory)) {
            playerInventory.AddItem(NPCInventory.TakeItem());
       }
    }
    public override void OnEnterState(GameObject gameObject)
    {
        gameObject.GetComponent<InteractableComponent>().OnInteract.AddListener(OnInteract);
    }

    public override void UpdateState(float dt, StateMachineComponent stateMachine, GameObject gameObject)
    {
        
    }

    public override void OnEndState(GameObject gameObject)
    {
        gameObject.GetComponent<InteractableComponent>().OnInteract.RemoveListener(OnInteract);
    }
}
