using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
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

        // Vector3 direction = player.transform.position - transform.position;
        // rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        hitColor = new Color(2.55f, 0.3f, 0.3f, 1f);
        startColor = new Color (2.55f, 2.55f, 2.55f, 1f);

        // transform.LookAt(player.transform.position);
        // rb.velocity = Vector3.forward * force;
        rb.velocity = (player.transform.position - transform.position).normalized * force;
        // float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg; 
        // transform.rotation = Quaternion.Euler(0, 0, rot + 90);
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
