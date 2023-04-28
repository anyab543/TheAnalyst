using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_FishTrack : MonoBehaviour
{
    private Vector2 currentLocation;
    private Vector2 cameraLocation;
    private GameObject cam;
    private float currentX;
    private float currentY;
    private float distanceFromCamera;
    private bool inRange;

    private Rigidbody2D rb;
    

    public float speed;
    private Transform target;

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
			Vector2 lookDir = target.position - transform.position;
			
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 180f;
			rb.rotation = angle;
		}
    }
}
