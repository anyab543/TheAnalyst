using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RLBossHealthBar : MonoBehaviour
{
    public Slider slider;    

    private Image back_fill;

    private Health bossHealth;

    private int frames;

    // Start is called before the first frame update
    void Start()
    {
        bossHealth = GameObject.FindWithTag("Boss").GetComponent<Health>();
        slider.maxValue = 40;
        slider.value = 40;
        back_fill = GetComponent<Image>();
    }

    void Update()
    {
        slider.value = bossHealth.currentHealth;
        
    }
}
