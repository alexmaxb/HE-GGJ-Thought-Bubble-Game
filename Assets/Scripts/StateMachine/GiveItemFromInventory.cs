using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/GiveItemFromInventory")]
public class GiveItemFromInventory : NPCState
{


    public void OnInteract(InteractableComponent interactable, GameObject gameObject) {
        Debug.Log("Attempting to give item");
       if(interactable.TryGetComponent<ItemInventory>(out ItemInventory NPCInventory) && 
       gameObject.TryGetComponent<ItemInventory>(out ItemInventory playerInventory)) {
            InventoryItem item = NPCInventory.TakeItem();
            Debug.Log("Giving item: " + item.itemName);
            playerInventory.AddItem(item);
       }
    }
    public override void OnEnterState(GameObject gameObject)
    {
        Debug.Log("Entered GiveItemFromInventory state");
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
