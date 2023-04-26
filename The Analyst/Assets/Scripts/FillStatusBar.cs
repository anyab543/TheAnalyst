using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// // Assumes Player has a Player Health Script with Current Health and Max Health variables


public class FillStatusBar : MonoBehaviour
{
    
    private Health playerHealth;
    public Image fillImage;
    private Slider slider;

    


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue) {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled) {
            fillImage.enabled = true;
        }

        float fillValue = (float)(playerHealth.currentHealth) / (float)playerHealth.maxHealth;
        // if (fillValue <= slider.maxValue / 3) {
        //     fillImage.color = color.white; // critical condition
        // } else {
        //     fillImage.color = color.red;
        // }


        slider.value = fillValue;
    }
}
