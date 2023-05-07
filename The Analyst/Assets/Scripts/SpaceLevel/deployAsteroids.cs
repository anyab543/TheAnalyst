using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroids : MonoBehaviour
{
    public GameObject asteroids;
    public float respawnTime = 5.0f;
    //private Vector2 screenBounds;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }

    private void spawn() {
            GameObject a = Instantiate(asteroids) as GameObject;
            a.transform.position = new Vector2(Random.Range(-(cameraTransform.position.x), cameraTransform.position.x), cameraTransform.position.y + 8);
    }

    IEnumerator asteroidWave() {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawn();
        }
    }
}
