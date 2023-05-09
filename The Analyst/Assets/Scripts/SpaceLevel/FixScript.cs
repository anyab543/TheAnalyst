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
    private float waitTime = 3.0f;
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
                        fix.Play();
                        brokenWire.gameObject.SetActive(false);
                        StartCoroutine(waitWin());
                        SceneManager.LoadScene("Scene11a");
        }   
    }

    IEnumerator waitWin() {
            yield return new WaitForSeconds(waitTime);
    }
}
