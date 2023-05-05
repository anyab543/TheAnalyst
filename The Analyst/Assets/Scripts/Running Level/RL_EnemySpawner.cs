using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_EnemySpawner : MonoBehaviour
{
    [SerializeField] private float SpawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs; // Array of different kind of enemies
    [SerializeField] private bool canSpawn = true;


    private void start() {
        Debug.Log("In the Start function!");
        StartCoroutine(Spawner());
    }


    private IEnumerator Spawner() {
        WaitForSeconds wait = new WaitForSeconds(SpawnRate);

        while (canSpawn) {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);

            Debug.Log("In the function!");
            

            GameObject enemyToSpawn = enemyPrefabs[rand];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }

}
