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

    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        currentX = transform.position.x;
        currentY = transform.position.y;
        currentLocation = new Vector2(currentX, currentY);

        camera = GameObject.FindWithTag("MainCamera");
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        cameraLocation = new Vector2(22, camera.transform.position.y);
        distanceFromCamera = (currentLocation.y - cameraLocation.y);
        if (distanceFromCamera < 20 && distanceFromCamera > -20) {
            inRange = true;
        }
    }


    void FixedUpdate() {
        if (inRange) {
            if(left == true) {
                currentX = currentX - 0.05f;
            } else {
                currentX = currentX + 0.05f;
            }
            
            transform.position = new Vector3 (currentX, currentY, 0);
        }
        if (currentX >= 60f || currentX <= -20) {
            Destroy(gameObject);
        }
    }
}
