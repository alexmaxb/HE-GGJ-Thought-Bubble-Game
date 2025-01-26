using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public DialogueController dialogueController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowDialogue(string dialogue) {
        dialogueController.ShowDialogue(dialogue);
    }
}
