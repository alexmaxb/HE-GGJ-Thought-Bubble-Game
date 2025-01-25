using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBubbleFunctionalityScript : MonoBehaviour
{

    public InteractableComponent object1;
    public InteractableComponent object2;

    public bool tradeWithObject1 = false;
    public bool tradeWithObject2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tradeWithObject1) {
            tradeWithObject1 = false;
            object1.Interact(this.gameObject);
        }

        if(tradeWithObject2) {
            tradeWithObject2 = false;
            object2.Interact(this.gameObject);
        }
    }
}
