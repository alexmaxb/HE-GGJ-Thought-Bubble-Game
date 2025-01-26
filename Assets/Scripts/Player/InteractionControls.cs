using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class InteractionControls : MonoBehaviour
{
    public float interactRange = 3;
    public float castWidth = .1f;

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
                Debug.Log("Interact Pressed. Found interactable object");
                interactable.Interact(this.gameObject);
            } else Debug.Log("Interact Pressed. object not interactable");
        } else Debug.Log("Interact Pressed. Didn't detect object");
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

        Vector2 pos = transform.position;

        //Collider2D hit = Physics2D.Linecast(pos, pos + GetComponent<Move>().cachedDirection * interactRange, LayerMask.GetMask("Default")).collider;
        Collider2D hit = Physics2D.CircleCast(transform.position, castWidth, GetComponent<Move>().cachedDirection, interactRange, LayerMask.GetMask("Default")).collider;
        return hit==null? null : hit.gameObject;
        
    }
}
