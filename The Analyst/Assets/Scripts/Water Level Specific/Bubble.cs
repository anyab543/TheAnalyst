using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private GameObject parent;
    public BreathMeter breath_meter;
    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player")) {
            breath_meter.found_bubble();
            Destroy(parent);
            Debug.Log("Collision");
        }
    }
    
}
