using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableComponent))]
public class NPC : MonoBehaviour
{

    [SerializeField]
    public string id ;//{get; private set;}

    [SerializeField]
    public string category ;//{get; private set;}

    public string defaultDialogue = "";
    private string currentDialogue;
    

    void Awake() {
        currentDialogue = defaultDialogue;
        GetComponent<InteractableComponent>().OnInteract.AddListener(OnInteract);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnInteract(InteractableComponent interactable, GameObject target) {
        if(target.TryGetComponent<Player>(out Player player)) {
            // Display dialogue
        }
    }

    public void SetCurrentDialogue(string dialogue) {
        currentDialogue = dialogue;
    }

    public void ResetDialogue() {
        currentDialogue = defaultDialogue;
    }
}
