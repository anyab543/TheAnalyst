using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseReveal : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float disappearTimerCurr;
    private float disappearTimerMax;
    private Color color;
    
    // Start is called before the first frame update
    void Start() {
        //this.SetActive(false);
    }
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        disappearTimerMax = 1f;
        disappearTimerCurr = 0f;
        color = new Color(1, 1, 1, 1f);
    }

    // Update is called once per frame
    private void Update()
    {
        disappearTimerCurr += Time.deltaTime / 4;

        color.a = Mathf.Lerp(disappearTimerMax, 0f, disappearTimerCurr / disappearTimerMax);
        spriteRenderer.color = color;

        if (disappearTimerCurr >= disappearTimerMax) {
            disappearTimerCurr = 0;
            gameObject.SetActive(false);
        }
    }

    public void setTimer() {
        disappearTimerCurr = 0;
    }
}
