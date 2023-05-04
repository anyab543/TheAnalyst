using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    private GameObject player;
    private Health playerHealth;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    private Color startColor;
    private Color hitColor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindWithTag("GameHandler").GetComponent<Health>();
        // originalPlayerColor = player.GetComponentInChildren<SpriteRenderer>().color;
        hitColor = new Color(2.55f, 0.3f, 0.3f, 1f);
        startColor = new Color (2.55f, 2.55f, 2.55f, 1f);
        rb.velocity = (player.transform.position - transform.position).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Player")) {
            SpriteRenderer playerRend = other.transform.GetComponentInChildren<SpriteRenderer>();
            StartCoroutine(hitPlayer(playerRend));
        }
    }

    private IEnumerator hitPlayer(SpriteRenderer renderer)
    {
        playerHealth.TakeDamage(3);
        renderer.color = hitColor;
        yield return new WaitForSeconds(0.3f);
        renderer.color = startColor;
        Destroy(gameObject);
    }
}
