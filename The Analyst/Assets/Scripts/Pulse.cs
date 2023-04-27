using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    private Transform pulseTransform;
    private float rangeCurr;
    public float rangeMax;
    private List<Collider2D> alreadyPinged;
    private bool pulseIsActive;

    public AudioClip activate_sound;
    public AudioClip hit_sound;
    private AudioSource audioS;

    void Start() {
        pulseIsActive = false;
    }

    private void Awake() {
        pulseTransform = transform.Find("Pulse_Graphic");
        rangeMax = 45f;
        alreadyPinged = new List<Collider2D>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E)) {
            if (pulseIsActive == false) {
                audioS.PlayOneShot(activate_sound);
            }
            pulseIsActive = true;
        }
        
        if (pulseIsActive) {
            float rangeSpeed = 25f;
            rangeCurr += rangeSpeed * Time.deltaTime;

            if (rangeCurr > rangeMax) {
                rangeCurr = 0f;
                alreadyPinged.Clear();
                pulseIsActive = false;
            }

            pulseTransform.localScale = new Vector3(rangeCurr, rangeCurr);

            RaycastHit2D[] raycastHit2DArray = Physics2D.CircleCastAll(transform.position, rangeCurr/ 2f, Vector2.zero);
            foreach (RaycastHit2D raycastHit2D in raycastHit2DArray) {
                if (raycastHit2D.collider != null) {
                    if (!alreadyPinged.Contains(raycastHit2D.collider)) {
                        alreadyPinged.Add(raycastHit2D.collider);
                    
                        Transform transformHit = raycastHit2D.transform;
                        if (transformHit.CompareTag("Hidden")) {
                            GameObject objectHit = transformHit.GetChild(0).gameObject;
                            objectHit.SetActive(true);
                            objectHit.GetComponent<PulseReveal>().setTimer();
                            

                            //Debug.Log("hit hidden object!");
                            audioS.PlayOneShot(hit_sound);
                        } else {
                            //Debug.Log("hit visibile object!");
                        }
                    
                    }
                }
            }
        
        }

    }
}
