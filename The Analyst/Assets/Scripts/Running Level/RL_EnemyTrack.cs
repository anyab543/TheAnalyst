using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_EnemyTrack : MonoBehaviour
{
    private Vector2 currentLocation;
    private Vector2 cameraLocation;
    private GameObject cam;
    private float currentX;
    private float currentY;
    private float distanceFromCamera;
    private bool inRange;
    private bool flip;

    private Rigidbody2D rb;
    

    private float speed;
    private Transform target;
    private float rotation_offset;

    // Start is called before the first frame update
    void Start()
    {
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentLocation = new Vector2(currentX, currentY);

        cam = GameObject.FindWithTag("MainCamera");
        inRange = false;

        rb = this.GetComponent<Rigidbody2D>();

        if (GameObject.FindGameObjectWithTag ("Player") != null) {
			target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		}
        flip = false;
        rotation_offset = 180f;
        speed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        cameraLocation = new Vector2(22, cam.transform.position.y);
        distanceFromCamera = (currentLocation.y - cameraLocation.y);
        if (distanceFromCamera < 20 && distanceFromCamera > -20) {
            inRange = true;
        }
    }

    void FixedUpdate() {
        if (target != null && inRange){
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			


            // if (target.position.x > transform.position.x) {
            //     flip = true;
            // } else {
            //     flip = false;
            // }

            if (!flip & target.position.x > transform.position.x) {
                Vector3 newScale =transform.localScale;
                newScale.x = -1.0f;
                transform.localScale = newScale;
                flip = true;
                rotation_offset = 0f;
            } else if (flip & target.position.x < transform.position.x) {
                Vector3 newScale =transform.localScale;
                newScale.x = 1.0f;
                transform.localScale = newScale;
                flip = false;
                rotation_offset = 180f;
            }


            Vector2 lookDir = target.position - transform.position;
			
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + rotation_offset;
			rb.rotation = angle;
		}

    
    }
}
