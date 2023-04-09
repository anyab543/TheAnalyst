using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathMeter : MonoBehaviour
{
    public Slider slider;
    private float timer_curr;
    public float bubble_value;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 100;
        slider.value = 100;
        timer_curr = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timer_curr -= Time.deltaTime * 2;
        slider.value = timer_curr;
    }

    public void found_bubble() {
        
        timer_curr += bubble_value;
        if (timer_curr > 100) {
            timer_curr = 100;
        }
    }
}
