using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    [SerializeField]
    public InventoryItem[] heldObjects;

    public bool enableAudio = false;
    public RandomAudioPlayer inventoryAudioPlayer;

    public List<InventoryItem> currentInventory {get; private set;}

    void Awake() {
        currentInventory = new List<InventoryItem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(var item in heldObjects) {
            currentInventory.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InventoryItem TakeItem() {
        if(currentInventory.Count == 0) return null;

        InventoryItem item = currentInventory[0];
        currentInventory.Remove(item);

        item.gameObject.transform.parent = null;

        return item;
    }

    public bool RemoveItem(InventoryItem item){

        if(currentInventory.Remove(item)) {
            item.transform.parent = null;
            return true;
        }

        return false;
    }


    public void AddItem(InventoryItem item) {

        Debug.Log("Received item: " + item.itemName);

        currentInventory.Add(item);

        if(enableAudio && inventoryAudioPlayer != null) {
            inventoryAudioPlayer.PlayClip();
        }

        item.gameObject.transform.parent = gameObject.transform;
    }

    public bool CheckForItem(string itemName) {
        foreach(InventoryItem item in currentInventory) {
            if(item.itemName == itemName) {
                return true;
            }
        }

        return false;
    }
}
