using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private GameObject parent;
    private Health playerHealth;
    private BreathMeter breath_meter;
    private TransitionHandler handler;
    private bool bubble_hit;

    private AudioSource pop;
    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        breath_meter = GameObject.FindGameObjectWithTag("breathMeter").GetComponent<BreathMeter>();
        playerHealth = GameObject.FindWithTag("GameHandler").GetComponent<Health>();
        handler = GameObject.FindGameObjectWithTag("TransitionHandler").GetComponent<TransitionHandler>();
        pop = gameObject.GetComponent<AudioSource>();
        bubble_hit = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player") & !bubble_hit) {
            bubble_hit = true;
            pop.Play();
            breath_meter.found_bubble();
            playerHealth.Heal(5);

            if(handler.phase2) {
                handler.bubble_pop();
            }

            StartCoroutine(destroy_bubble());
        }
    }

    private IEnumerator destroy_bubble() {
        
        yield return new WaitForSeconds(0.2f);
        Destroy(parent);
    }    
}
