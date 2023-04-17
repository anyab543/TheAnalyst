using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    public Health playerHealth;
    private Health enemyHealth;
    private bool canDamage;
    private int damageTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        canDamage = true;
        damageTimer = 0;
        enemyHealth = GetComponent<Health>();
    }

    void FixedUpdate() {
        if (damageTimer > 0) {
            damageTimer--;
        } else {
            canDamage = true;
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player") && canDamage) {
            playerHealth.TakeDamage(5);
            damageTimer = 60;
            canDamage = false;
        }

        if(other.transform.CompareTag("Bullet")) {
            enemyHealth.TakeDamage(1);
            if (enemyHealth.isDead()) {
                Destroy(gameObject);
            }
            Destroy(other.transform.gameObject);
        }

    }
}
