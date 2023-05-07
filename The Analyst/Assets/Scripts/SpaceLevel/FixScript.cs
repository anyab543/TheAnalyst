using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixScript : MonoBehaviour
{
    private Inventory inventory;
    public GameObject fixedWire;
    public GameObject brokenWire;
    public GameObject pressSpace;
    public bool isCurrentlyColliding;

    // Start is called before the first frame update
    void Start()
    {
        isCurrentlyColliding = false;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        isCurrentlyColliding = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        isCurrentlyColliding = false;
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space) && inventory.isFull[0] == true && inventory.isFull[1] == true && isCurrentlyColliding == true) {
                        fixedWire.gameObject.SetActive(true);
                        brokenWire.gameObject.SetActive(false); 
        }   
        if(inventory.isFull[0] == true && inventory.isFull[1] == true) {
            if (isCurrentlyColliding == true) {
                pressSpace.gameObject.SetActive(true);
            }
        }
    }
}
