using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionControls : MonoBehaviour
{
    public float interactRange = 3;

    public KeyCode interactKeyCode;
    private bool isInteractPressed = false;


    public KeyCode swapKeyCode;
    private bool isSwapPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(interactKeyCode)) {
            if(!isInteractPressed) {
                isInteractPressed = true;
                OnInteractPressed();
            }
        }
        else {
            isInteractPressed = false;
        }

        if(Input.GetKeyDown(swapKeyCode)) {
            if(!isSwapPressed) {
                isSwapPressed = true;
                OnSwapPressed();
            }
        }
        else {
            isSwapPressed = false;
        }
    }


    private void OnInteractPressed() {
        GameObject target = DetectObject();
        if(target != null) {
            InteractableComponent interactable = target.GetComponent<InteractableComponent>();
            if(interactable) {
                interactable.Interact(this.gameObject);
            }
        }
    }

    private void OnSwapPressed() {
        GameObject target = DetectObject();
        if(target != null) {
            ThoughtBubbleComponent thoughtBubbleComponent = target.GetComponent<ThoughtBubbleComponent>();
            if(thoughtBubbleComponent) {
                thoughtBubbleComponent.OnInteract(this.gameObject);
            }
        }
    }

    public GameObject DetectObject() {

        Collider2D hit = Physics2D.Linecast(transform.position, transform.position + transform.forward * interactRange).collider;
        return hit==null? null : hit.gameObject;
        
    }
}
