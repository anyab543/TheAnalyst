// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class RL_EnemySpawner : MonoBehaviour
// {
//     // [SerializeField] private float SpawnRate = 1f;
//     // [SerializeField] private GameObject[] enemyPrefabs; // Array of different kind of enemies
//     // [SerializeField] private bool canSpawn = true;

//     [SerializeField] private GameObject skeletonPrefab;
//     [SerializeField] private GameObject ghostPrefab;
    
//     [SerializeField] private float skeletonInterval = 3.5f;
//     [SerializeField] private float ghostInterval = 5f;


//     private void Start() {
//         // Debug.Log("In the Start function!");
//         // StartCoroutine(Spawner());
//         StartCoroutine(spawnEnemy(skeletonInterval, skeletonPrefab));
//         StartCoroutine(spawnEnemy(ghostInterval, ghostPrefab));
//     }


//     // private IEnumerator Spawner() {
//     //     WaitForSeconds wait = new WaitForSeconds(SpawnRate);

//     //     while (canSpawn) {
//     //         yield return wait;
//     //         int rand = Random.Range(0, enemyPrefabs.Length);

//     //         Debug.Log("In the function!");
            

//     //         GameObject enemyToSpawn = enemyPrefabs[rand];
//     //         Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
//     //     }
//     // }

//     private IEnumerator spawnEnemy(float interval, GameObject enemy)
//     {
//         yield return new WaitForSeconds(interval);
//         Instantiate(enemy, transform.position, Quaternion.identity);
//         StartCoroutine(spawnEnemy(interval, enemy));
//     }

// }






using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_EnemySpawner : MonoBehaviour
{
    
    private float teleport_timer;
    public GameObject player;
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject ghostPrefab;
    private Health boss_health;
    
    public bool boss_p1;
    public bool boss_p2;
    public bool boss_p3;
    public bool boss_p4;
    public bool final_stand;

    public AudioClip tp_sfx;
    public AudioClip shoot_sfx;
    private AudioSource audioS;

    

    //private TransitionHandler tHandler;


    // Start is called before the first frame update
    void Start()
    {
        teleport_timer = 3f;
        player = GameObject.FindGameObjectWithTag("Player");
        boss_health = GetComponent<Health>();
        boss_p1 = true;
        boss_p2 = false;
        boss_p3 = false;
        boss_p4 = false;
        final_stand = false;
        //tHandler = GameObject.FindWithTag("TransitionHandler").GetComponent<TransitionHandler>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!final_stand) {
            teleport_timer += Time.deltaTime;
        }
        

        if (teleport_timer >= 4f) {
            teleport_timer = 0;
            // Debug.Log("Teleporting");
            boss_teleport();
            if (boss_p1) {
                StartCoroutine(shoot1());
            } else if (boss_p2) {
                StartCoroutine(shoot2());
            } else if (boss_p3) {
                StartCoroutine(shoot3());
            } else if (boss_p4) {
                StartCoroutine(shoot4());
            }
        }

        if(boss_p1 & boss_health.currentHealth <= 75) {
            boss_p2 = true;
            boss_p1 = false;

        } else if (boss_p2 & boss_health.currentHealth <= 50) {
            boss_p3 = true;
            boss_p2 = false;
        } else if (boss_p3 & boss_health.currentHealth <= 25) {
            boss_p4 = true;
            boss_p3 = false;
        } else if (boss_p4 & boss_health.currentHealth <= 2) {
            boss_p4 = false;
            final_stand = true;
            gameObject.transform.position = new Vector3 (22, -350, 0);
            StartCoroutine(finalStand());
        } else if (final_stand & boss_health.currentHealth <= 0) {
            final_stand = false;
            //tHandler.boss_dead = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            boss_health.TakeDamage(2);
            Destroy(other.transform.gameObject);
        }
    }


    private void boss_teleport() {
        float newx = player.transform.position.x;
        float newy = Random.Range(-341, -359);
        while (Mathf.Abs(newx - player.transform.position.x) < 9) {
            newx = Random.Range(4, 40);
        }
        audioS.PlayOneShot(tp_sfx);
        gameObject.transform.position = new Vector3 (newx, newy, 0);
    }
    

    private IEnumerator shoot1()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(skeletonPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(skeletonPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
    }

    private IEnumerator shoot2()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);


        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);  
    }

    private IEnumerator shoot3()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(skeletonPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);


        audioS.PlayOneShot(shoot_sfx);
        Instantiate(skeletonPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator shoot4()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(ghostPrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator finalStand() {
        float delay = 0.1f;
        while (boss_health.currentHealth > 0) {
            delay += 0.1f;
            boss_teleport();
            yield return new WaitForSeconds(0.3f);
            audioS.PlayOneShot(shoot_sfx);
            Instantiate(ghostPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
}
}



