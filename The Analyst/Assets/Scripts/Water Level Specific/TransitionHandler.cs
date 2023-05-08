using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionHandler : MonoBehaviour
{
    public bool phase2;
    private bool pullCam;
    private GameObject mainCam;
    private float camY;  
    public BreathMeter breath_meter;

    public GameObject player;
    public Health playerHealth;

    public int bubble_cap;
    public int curr_bubbles;
    public bool boss_dead;


    private AudioSource boom;
    public GameObject phase2_music;

    private GameObject boss;
    private GameObject boss_hb;
    public GameObject dreamer2;

    // Start is called before the first frame update
    void Start()
    {
        phase2 = false;
        pullCam = false;
        // mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<Health>();
        //camY = -267f;
        camY = 0f;
        boom = GetComponent<AudioSource>();

        boss = GameObject.FindWithTag("Boss");
        boss.SetActive(false);
        boss_hb = GameObject.FindWithTag("boss_HB");
        boss_hb.SetActive(false);
        dreamer2.SetActive(false);

        boss_dead = false;

    }

    void FixedUpdate()
    {
        // phase 1
        if (!phase2) {
            phase1Move();
        }
        
        // phase 2
        if (pullCam) {
            camY -= 0.6f;
            mainCam.transform.position = new Vector3 (22, camY, -10);
            
            player.transform.position = new Vector3 (22, camY, 0);

            if (camY <= -350) {
                pullCam = false;
                phase2_music.SetActive(true);
                boss.SetActive(true);
                boss_hb.SetActive(true);
            }
        }

        if (boss_dead) {
            playerHealth.Heal(100);
            breath_meter.fill_meter();
            phase2_music.SetActive(false);
            Destroy(boss);
            boss_hb.SetActive(false);
            dreamer2.SetActive(true);
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Hidden");
            foreach (GameObject obj in gameObjects) {
                Destroy(obj);
            }
        }
    }

    public void MyTrigger() {
        phase2 = true;
        pullCam = true;
        breath_meter.fill_meter();
        boom.Play();
        
    }

    public void bubble_pop() {
        curr_bubbles--;
    }

    private void phase1Move() {
        if (mainCam.transform.position.y > -267) {
            camY = camY - 0.056f;
            // camY = camY - 0f;
            // camY = camY - 0.7f;

            mainCam.transform.position = new Vector3 (22, camY, -10);
        } else {
            
        }
    }
}

