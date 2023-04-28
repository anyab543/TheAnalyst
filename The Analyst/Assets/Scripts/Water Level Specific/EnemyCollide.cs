using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    private Health playerHealth;
    private Health enemyHealth;
    private bool canDamage;
    private int damageTimer;
    private AudioSource hit_sfx;
    private Color originalColor;
    private Color originalPlayerColor;
    private SpriteRenderer rend;
    private Color hitColor;


    // private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindWithTag("GameHandler").GetComponent<Health>();
        originalPlayerColor = GameObject.FindWithTag("Player").GetComponentInChildren<SpriteRenderer>().color;
        canDamage = true;
        damageTimer = 0;
        if (this.transform.CompareTag("WaterLevelGhost")) {
            enemyHealth = transform.parent.gameObject.GetComponent<Health>();
        } else {
            enemyHealth = GetComponent<Health>();
        }
        rend = gameObject.GetComponentInChildren<SpriteRenderer>();
        // rb = gameObject.GetComponent<Rigidbody2D>();
        originalColor = rend.color;
        //Debug.Log("" + originalColor);
        hitColor = Color.red;
        //Debug.Log("" + hitColor);
        hit_sfx = GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        if (damageTimer > 0) {
            damageTimer--;
        } else {
            canDamage = true;
            //rend.color = originalColor;
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player") && canDamage) {
            SpriteRenderer playerRend = other.transform.GetComponentInChildren<SpriteRenderer>();
            StartCoroutine(ChangeColor(playerRend, originalPlayerColor));
            playerHealth.TakeDamage(5);
            damageTimer = 60;
            canDamage = false;
            
        }

        if(other.transform.CompareTag("Bullet")) {
            Rigidbody2D bulletRB = other.transform.GetComponent<Rigidbody2D>();
            // Vector3 bulletVelocity = bulletRB.velocity;
            // rb.AddForce(bulletVelocity * 0.1, ForceMode2D.Force);
            StartCoroutine(ChangeColor(rend, originalColor));
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
    private IEnumerator ChangeColor(SpriteRenderer renderer, Color original)
    {
        renderer.color = hitColor;
        yield return new WaitForSeconds(0.3f);
        renderer.color = original;
    }
}
