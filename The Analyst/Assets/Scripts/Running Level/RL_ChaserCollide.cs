using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_ChaserCollide : MonoBehaviour
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
        // if (this.transform.CompareTag("WaterLevelGhost")) {
        //     enemyHealth = transform.parent.gameObject.GetComponent<Health>();
        // } else {
        //     enemyHealth = GetComponent<Health>();
        // }
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
            Debug.Log("Enemy Hit");
            SpriteRenderer playerRend = other.transform.GetComponentInChildren<SpriteRenderer>();
            StartCoroutine(ChangeColor(playerRend, originalPlayerColor));
            playerHealth.TakeDamage(15);
            damageTimer = 60;
            canDamage = false;
            
        }

        }
        
    private IEnumerator ChangeColor(SpriteRenderer renderer, Color original)
    {
        renderer.color = hitColor;
        yield return new WaitForSeconds(0.3f);
        renderer.color = original;
    }
}
