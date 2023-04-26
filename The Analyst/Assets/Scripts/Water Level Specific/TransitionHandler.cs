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
        camY = -267f;

        boom = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
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
}
