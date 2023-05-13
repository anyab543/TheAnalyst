using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour {
    private float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float timer;


    // Use this for initialization
    void Start () {
        speed = 1.5f + Random.Range(-1f, 0.5f);
        Debug.Log(speed);
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = (new Vector2(-speed, -speed));

        // rb.velocity = (new Vector2(0, -speed) + new Vector2(-speed, 0)).normalized;
        timer = 0;
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void FixedUpdate () {

        timer += Time.deltaTime;
        if (timer >= 30f) {
            Destroy(gameObject);
        }
        // if(transform.position.x < screenBounds.x * 2){
        //     Destroy(this.gameObject);
        // }
    }
}
