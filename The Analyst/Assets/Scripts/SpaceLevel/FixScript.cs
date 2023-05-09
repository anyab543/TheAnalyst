using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FixScript : MonoBehaviour
{
    private Inventory inventory;
    public GameObject fixedWire;
    public GameObject brokenWire;
    public GameObject pressSpace;
    public bool isCurrentlyColliding;
    private float waitTime = 5.0f;
    private AudioSource fix;

    // Start is called before the first frame update
    void Start()
    {
        isCurrentlyColliding = false;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        fix = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        isCurrentlyColliding = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        isCurrentlyColliding = false;
    }

    void Update() {
        if(inventory.isFull[0] == true && inventory.isFull[1] == true) {
            if (isCurrentlyColliding == true) {
                pressSpace.gameObject.SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.Space) && inventory.isFull[0] == true && inventory.isFull[1] == true && isCurrentlyColliding == true) {
                        fixedWire.gameObject.SetActive(true);
                        
                        brokenWire.gameObject.SetActive(false);
                        StartCoroutine(waitWin());
                        
        }   
    }

    IEnumerator waitWin() {
            fix.Play();
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene("Scene11a");
    }
}
