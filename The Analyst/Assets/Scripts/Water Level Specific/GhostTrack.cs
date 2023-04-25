using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrack : MonoBehaviour
{
    private Vector2 currentLocation;
    private float currentX;
    private float currentY;
    private float distanceFromCamera;
    private bool inRange;

    private Rigidbody2D rb;
    
    private AudioSource appear;
    private bool sound_played;

    public float speed;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        appear = GetComponent<AudioSource>();
        sound_played = false;

        currentX = transform.position.x;
        currentY = transform.position.y;
        currentLocation = new Vector2(currentX, currentY);

        rb = this.GetComponent<Rigidbody2D>();

        if (GameObject.FindGameObjectWithTag ("Player") != null) {
			target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		}
    }


    void FixedUpdate() {
        if (target != null){
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			
		}

        if((target.position - transform.position).magnitude < 5) {
            this.transform.GetChild(0).gameObject.SetActive(true);
            if (!sound_played) {
                appear.Play();
                sound_played = true;
            } 
        } else {
            sound_played = false;
        }

    }
}
