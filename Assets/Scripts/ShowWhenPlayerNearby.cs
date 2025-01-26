using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowWhenPlayerNearby : MonoBehaviour
{


    public float radius = 3;

    public GameObject bubbleGameObject;

    private CircleCollider2D trigger;

    public SpriteRenderer thoughtIcon;


    void Awake() {
        trigger = gameObject.AddComponent<CircleCollider2D>();
        trigger.radius = radius;
        trigger.isTrigger = true;

        bubbleGameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSwitchBubbleIcon(Sprite newBubbleIcon) {
        thoughtIcon.sprite = newBubbleIcon;
    }

    void OnTriggerEnter2D(Collider2D col) {
        // check player
        if(col.GetComponent<Player>() != null){
            bubbleGameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        // check player
        if(col.GetComponent<Player>() != null){
            bubbleGameObject.SetActive(false);
        }
    }
}
