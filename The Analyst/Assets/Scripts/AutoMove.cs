using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public bool isMoving;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        y = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving) {
            y = y - 0.04f;
            transform.position = new Vector3 (22, y, -10);
        }
    }
}