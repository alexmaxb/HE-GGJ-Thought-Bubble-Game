using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour
{
    /**
    * Event for when a gameobject interacts with this gameobject
    * InteractableComponent - this gameobject - used for cases where the listener doesn't have access to the current gameobject
    * Gameobject - the object interacting with this object
    * 
    */
    public UnityEvent<InteractableComponent, GameObject> OnInteract = new UnityEvent<InteractableComponent, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject player) {
        OnInteract.Invoke(this, player);
    }


    
}
