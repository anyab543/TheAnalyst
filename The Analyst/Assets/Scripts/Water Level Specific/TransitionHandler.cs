using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionHandler : MonoBehaviour
{
    public bool phase2;
    private bool pullCam;
    private Camera mainCam;
    private float camY;  
    public BreathMeter breath_meter;
    public GameObject player;
    public int bubble_cap;
    public int curr_bubbles;

    private AudioSource boom;


    // Start is called before the first frame update
    void Start()
    {
        phase2 = false;
        pullCam = false;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        //camY = -267f;
        camY = 0f;
        boom = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        if (!phase2) {
            phase1Move();
        }
        
        if (pullCam) {
            camY -= 0.6f;
            mainCam.transform.position = new Vector3 (22, camY, -10);
            
            //#if UNITY_STANDALONE
            if (player.transform.position == null) {
                Debug.Log("UH OH");
            }
            player.transform.position = new Vector3 (22, camY, 0);

            if (camY <= -350) {
                pullCam = false;
            }
        }
    }

    public void Trigger() {
        phase2 = true;
        pullCam = true;
        breath_meter.fill_meter();
        boom.Play();
        
    }

    public void pop() {
        curr_bubbles--;
    }

    private void phase1Move() {
        if (mainCam.transform.position.y > -267) {
            camY = camY - 0.057f;
            //camY = camY - 0.5f;

            mainCam.transform.position = new Vector3 (22, camY, -10);
        } else {
            
        }
    }
}

