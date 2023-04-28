using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_fishMove : MonoBehaviour
{
    private Vector2 currentLocation;
    private Vector2 cameraLocation;
    private GameObject cam;
    private float currentX;
    private float currentY;
    private float distanceFromCamera;
    private bool inRange;

    public bool left;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentLocation = new Vector2(currentX, currentY);

        cam = GameObject.FindWithTag("MainCamera");
        inRange = false;

        spr = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (left) {
            spr.flipX = true;
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
        if (inRange) {
            if(left == true) {
                //currentX = currentX - 0.05f;
                currentY = currentY - 0.05f;
            } else {
                //currentX = currentX + 0.05f;
                currentY = currentY + 0.05f;
            }
            
            transform.position = new Vector3 (currentX, currentY, 0);
        }
        if (currentX >= 60f || currentX <= -20) {
            Destroy(gameObject);
        }
    }
}
