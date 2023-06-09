using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public GameObject gameObject;
    private AudioSource pickup;
    //public GameHandler gameHandlerObj;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        pickup = gameObject.GetComponent<AudioSource>();
        // if (GameObject.FindWithTag("GameHandler") != null)
        // {
        //     gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandlerScript>();
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            for (int i = 0; i < inventory.slots.Length; i++){
                if (inventory.isFull[i] == false) {
                    pickup.Play();
                    /* item can be added to inventory */
                    inventory.isFull[i] = true;
                    /* button goes to same place as slot */
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject.transform.parent.gameObject); /* remove picked up item */

                    break;
                }
            }
        }
    }
}

