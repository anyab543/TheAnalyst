using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseCoolDown : MonoBehaviour
{
    public int pulse_charges;
    private float timer;
    private bool timer_on;
    private GameObject img1;
    private GameObject img2;
    private GameObject img3;
    
    // Start is called before the first frame update
    void Start()
    {
        pulse_charges = 3;
        timer = 0;
        timer_on = false;

        img1 = this.gameObject.transform.GetChild(0).gameObject;
        img2 = this.gameObject.transform.GetChild(1).gameObject;
        img3 = this.gameObject.transform.GetChild(2).gameObject;
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
            }
        }

        if (pulse_charges == 0) {
            img1.SetActive(false);
            img2.SetActive(false);
            img3.SetActive(false);
        } else if (pulse_charges == 1) {
            img1.SetActive(true);
            img2.SetActive(false);
            img3.SetActive(false);
        } else if (pulse_charges == 2) {
            img1.SetActive(true);
            img2.SetActive(true);
            img3.SetActive(false);
        } else if (pulse_charges == 3) {
            img1.SetActive(true);
            img2.SetActive(true);
            img3.SetActive(true);
        }

    }
}
