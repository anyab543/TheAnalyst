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

    private GameObject ob;
    private Camera mainCam;  
    public TransitionHandler handler;

    private AudioSource jumpscare;
    private bool sound_played;

    
    // Start is called before the first frame update
    void Start() {
        //this.SetActive(false);
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        timer = 0;
        ob = gameObject;
        jumpscare = ob.GetComponent<AudioSource>();
        sound_played = false;
    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if (mainCam.transform.position.y <= -267) {
            if (timer <= 5) {
                timer += Time.deltaTime;
            } 
            if (timer >= 3 && !handler.phase2) {  
                if (!sound_played) {
                    jumpscare.Play();
                    sound_played = true;
                }
                ob.transform.position = new Vector3 (25, (float)(ob.transform.position.y - 0.5), 0);
                
            }  

            if (timer >= 4 && !handler.phase2) {
                handler.MyTrigger();
                gameObject.SetActive(false);
            } 
        }
        
        
    }

    // public void setTimer() {
    //     disappearTimerCurr = 0;
    // }
}
