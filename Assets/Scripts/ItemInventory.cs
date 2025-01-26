using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] heldObjects;

    public bool enableAudio = false;
    public RandomAudioPlayer inventoryAudioPlayer;

    public List<GameObject> currentInventory {get; private set;}

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

    public GameObject TakeItem() {
        if(heldObjects.Length == 0) return null;

        GameObject item = currentInventory[0];
        currentInventory.Remove(item);

        item.transform.parent = null;

        return item;
    }

    public bool RemoveItem(GameObject gameObject){

        if(currentInventory.Remove(gameObject)) {
            gameObject.transform.parent = null;
            return true;
        }

        return false;
    }


    public void AddItem(GameObject item) {
        currentInventory.Add(item);

        if(enableAudio && inventoryAudioPlayer != null) {
            inventoryAudioPlayer.PlayClip();
        }
    }
}
