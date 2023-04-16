using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    public Health playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")) {
            playerHealth.TakeDamage(5);
        }
    }
}
