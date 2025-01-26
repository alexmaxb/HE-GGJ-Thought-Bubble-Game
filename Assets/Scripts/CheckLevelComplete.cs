using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class CheckLevelComplete : MonoBehaviour
{
    public GameObject[] GuardsThatNeedToBeDistracted;

    public string[] requiredInventoryItems;

    public string nextScene;

    public string failScene;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.TryGetComponent<Player>(out Player player)) {
            ItemInventory inventory = player.GetComponent<ItemInventory>();

            // check if required items are present
            foreach(var item in requiredInventoryItems) {
                if(!inventory.CheckForItem(item)) {
                    FailLevel();
                }
            }

            // check if all guards are distracted
            foreach(var guard in GuardsThatNeedToBeDistracted) {
                if(guard.TryGetComponent(out Guard guardComponent)) {
                    if(guardComponent.isAlert) {
                        FailLevel();
                    }
                }
            }

            SceneManager.LoadScene(nextScene);

            
        }
    }

    public void FailLevel() {
        SceneManager.LoadScene(failScene);
    }
}
