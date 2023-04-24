using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamerWaterReveal : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // private float disappearTimerCurr;
    // private float disappearTimerMax;
    private Color color;
    private float timer;

    private GameObject parent;
    private Camera mainCam;  
    public TransitionHandler handler;

    private AudioSource jumpscare;
    private bool sound_played;

    
    // Start is called before the first frame update
    void Start() {
        //this.SetActive(false);
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        timer = 0;
        parent = this.transform.parent.gameObject;
        jumpscare = parent.GetComponent<AudioSource>();
        sound_played = false;
    }
    
    private void Awake()
    {
        // spriteRenderer = GetComponent<SpriteRenderer>();
        // disappearTimerMax = 1f;
        // disappearTimerCurr = 0f;
        // color = new Color(0.3f, 0.3f, 1, 1f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Debug.Log(mainCam.transform.position.y);
        if (mainCam.transform.position.y <= -267) {

            if (timer <= 5) {
                timer += Time.deltaTime;
            } 
            if (timer >= 3 && !handler.phase2) {  
                if (!sound_played) {
                    jumpscare.Play();
                    sound_played = true;
                }
                parent.transform.position = new Vector3 (25, (float)(parent.transform.position.y - 0.5), 0);
                
            }  

            if (timer >= 4 && !handler.phase2) {
                handler.Trigger();
                gameObject.SetActive(false);
            } 
        }
        
        
    }

    // public void setTimer() {
    //     disappearTimerCurr = 0;
    // }
}