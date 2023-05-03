using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private GameObject parent;
    private BreathMeter breath_meter;
    private TransitionHandler handler;

    private AudioSource pop;
    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        breath_meter = GameObject.FindGameObjectWithTag("breathMeter").GetComponent<BreathMeter>();
        handler = GameObject.FindGameObjectWithTag("TransitionHandler").GetComponent<TransitionHandler>();
        pop = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player")) {
            pop.Play();
            breath_meter.found_bubble();

            if(handler.phase2) {
                handler.pop();
            }

            Destroy(parent);
        }
    }
    
}
