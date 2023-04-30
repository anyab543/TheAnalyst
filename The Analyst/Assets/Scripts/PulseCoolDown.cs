using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseCoolDown : MonoBehaviour
{
    public int pulse_charges;
    private float timer;
    private bool timer_on;
    
    // Start is called before the first frame update
    void Start()
    {
        pulse_charges = 3;
        timer = 0;
        timer_on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((pulse_charges < 3) & (!timer_on)) {
            timer_on = true;
        } 

        if (timer_on) {
            timer += Time.deltaTime;
            if (timer >= 5f) {
                timer = 0;
                timer_on = false;
                pulse_charges++;
                Debug.Log("restoring charge");
            }
        }

    }
}
