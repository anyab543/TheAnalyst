using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {

	public GameObject bubble;
	float randX;
	float randY;
	float currentX;
	float currentY;
	private Vector2 currentLocation;
	public float spawnWidth = 15.0f;
	public float spawnHeight = 5.0f;
	Vector2 whereToSpawn;
	public float SpawnRate;
	float nextSpawn;
	private float distanceFromPlayer;
	private bool spawnActive = false;

	public TransitionHandler handler;

	void Start (){
		currentX = transform.position.x;
		currentY = transform.position.y;
		currentLocation = new Vector2(currentX, currentY);
        spawnActive = false;
	}

	void Update () {
		//Debug.Log(distanceFromPlayer);
		//Debug.Log("hi");

		if (handler.phase2) {
			spawnActive = true;
		} 
		

		if ((Time.time > nextSpawn) & spawnActive & (handler.curr_bubbles < handler.bubble_cap)) {
			handler.curr_bubbles++;
            nextSpawn = Time.time + SpawnRate;
			randX = Random.Range(-1 * spawnWidth, spawnWidth);
			randY = Random.Range(-1 * spawnHeight, spawnHeight);
			whereToSpawn = new Vector2 (randX + currentX, randY + currentY);
			Instantiate (bubble, whereToSpawn, Quaternion.identity);
		}


	}

}
