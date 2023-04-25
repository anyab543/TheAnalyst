using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    public Health playerHealth;
    private Health enemyHealth;
    private bool canDamage;
    private int damageTimer;
    private AudioSource hit_sfx;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        canDamage = true;
        damageTimer = 0;
        if (this.transform.CompareTag("WaterLevelGhost")) {
            enemyHealth = transform.parent.gameObject.GetComponent<Health>();
        } else {
            enemyHealth = GetComponent<Health>();
        }
        


        hit_sfx = GetComponent<AudioSource>();
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
            hit_sfx.Play();
            enemyHealth.TakeDamage(1);
            if (enemyHealth.isDead()) {
                if (this.transform.CompareTag("WaterLevelGhost")) {
                    Destroy(transform.parent.gameObject);
                } else {
                    Destroy(gameObject);
                }
                
            }
            Destroy(other.transform.gameObject);
        }

    }
}
