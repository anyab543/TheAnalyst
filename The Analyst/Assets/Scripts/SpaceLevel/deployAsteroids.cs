using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroids : MonoBehaviour
{
    public GameObject asteroids;
    public float respawnTime = 25.0f;
    //private Vector2 screenBounds;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(asteroidWave());
    }

    private void spawn() {
            GameObject a = Instantiate(asteroids) as GameObject;
            a.transform.position = new Vector2(Random.Range(cameraTransform.position.x - 5, cameraTransform.position.x + 15), cameraTransform.position.y + 11);
    }

    IEnumerator asteroidWave() {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawn();
        }
    }
}
