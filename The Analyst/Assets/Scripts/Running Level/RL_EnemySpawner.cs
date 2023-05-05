using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_EnemySpawner : MonoBehaviour
{
    // [SerializeField] private float SpawnRate = 1f;
    // [SerializeField] private GameObject[] enemyPrefabs; // Array of different kind of enemies
    // [SerializeField] private bool canSpawn = true;

    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject ghostPrefab;
    
    [SerializeField] private float skeletonInterval = 3.5f;
    [SerializeField] private float ghostInterval = 5f;


    private void Start() {
        // Debug.Log("In the Start function!");
        // StartCoroutine(Spawner());
        StartCoroutine(spawnEnemy(skeletonInterval, skeletonPrefab));
        StartCoroutine(spawnEnemy(ghostInterval, ghostPrefab));
    }


    // private IEnumerator Spawner() {
    //     WaitForSeconds wait = new WaitForSeconds(SpawnRate);

    //     while (canSpawn) {
    //         yield return wait;
    //         int rand = Random.Range(0, enemyPrefabs.Length);

    //         Debug.Log("In the function!");
            

    //         GameObject enemyToSpawn = enemyPrefabs[rand];
    //         Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
    //     }
    // }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Instantiate(enemy, transform.position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
