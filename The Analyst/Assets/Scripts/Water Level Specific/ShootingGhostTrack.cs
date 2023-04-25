using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGhostTrack : MonoBehaviour
{
    private Vector2 currentLocation;
    private float currentX;
    private float currentY;
    private float distanceFromCamera;

    private Rigidbody2D rb;
    
    
    public float speed;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentLocation = new Vector2(currentX, currentY);


        rb = this.GetComponent<Rigidbody2D>();

        if (GameObject.FindGameObjectWithTag ("Player") != null) {
			target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		}
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        if (target != null){
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}
    }
}
