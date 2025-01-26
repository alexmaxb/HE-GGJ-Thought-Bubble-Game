using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{

    public TMP_Text text;

    public float secondsDialogueStaysVisible = 3;

    private float timeSinceShow = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceShow += Time.deltaTime;
        if(timeSinceShow > secondsDialogueStaysVisible) {
            text.gameObject.SetActive(false);
        }
    }

    public void ShowDialogue(string dialogue) {
        Debug.Log("Displaying dialogue: " + dialogue);
        text.text = dialogue;
        text.gameObject.SetActive(true);
        timeSinceShow = 0;
    }
}
