using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMove : MonoBehaviour
{
    private Vector2 currentLocation;
    private Vector2 cameraLocation;
    private GameObject camera;
    private float currentX;
    private float currentY;
    private float distanceFromCamera;
    private bool inRange;

    private float speed;

    public bool left;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.04f, 0.08f);
        
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentLocation = new Vector2(currentX, currentY);

        camera = GameObject.FindWithTag("MainCamera");
        inRange = false;

        spr = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (left) {
            spr.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraLocation = new Vector2(22, camera.transform.position.y);
        distanceFromCamera = (currentLocation.y - cameraLocation.y);
        if (distanceFromCamera < 15 && distanceFromCamera > -15) {
            inRange = true;
        }
    }


    void FixedUpdate() {
        if (inRange) {
            if(left == true) {
                currentX = currentX - speed;
            } else {
                currentX = currentX + speed;
            }
            
            transform.position = new Vector3 (currentX, currentY, 0);
        }
        if (currentX >= 60f || currentX <= -20) {
            Destroy(gameObject);
        }
    }
}
