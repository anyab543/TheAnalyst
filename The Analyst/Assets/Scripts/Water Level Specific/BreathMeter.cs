using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathMeter : MonoBehaviour
{
    public Slider slider;
    public float timer_curr;
    public float bubble_value;
    

    public Image black_screen;
    private bool near_drowning;
    private int shade_amount;
    private bool increasing;
    private AudioSource audioS;
    private Image back_fill;

    public Health playerHealth;

    private int frames;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 100;
        slider.value = 100;
        timer_curr = 100;
        near_drowning = false;
        increasing = true;
        shade_amount = 0;
        audioS = GetComponent<AudioSource>();
        back_fill = GetComponent<Image>();

        frames = 0;
    }

    void FixedUpdate() {
        
        if (timer_curr == 0) {
            frames++;
            if (frames % 3 == 0) {
                playerHealth.TakeDamage(1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer_curr > 0) {
            timer_curr -= Time.deltaTime * 2;
        } else {
            timer_curr = 0;
        }

       
        slider.value = timer_curr;

        if (timer_curr < 25) {
            near_drowning = true;
        }
        
        if (near_drowning) {
            if(shade_amount == 0 || shade_amount == 150) {
                audioS.Play();
            }

            if(increasing) {
                shade_amount++;
            } else {
                shade_amount--;
            }
            black_screen.color = new Color32(0,0,0, (byte)((float)shade_amount/1.3));
            back_fill.color = new Color32(255, (byte)(255 - ((float)shade_amount*1.7)), (byte)(255 - ((float)shade_amount*1.7)), 255);
            if(shade_amount == 150) {
                increasing = false;
            } else if (shade_amount == 0) {
                increasing = true;
            }
        }
        
        
    }

    public void found_bubble() {
        
        timer_curr += bubble_value;
        if (timer_curr > 100) {
            timer_curr = 100;
        }
        if (timer_curr > 25) {
            near_drowning = false;
            black_screen.color = new Color32(0,0,0,0);
            back_fill.color = new Color32(255,255,255,255);

        }
    }
}
