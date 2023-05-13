using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossControl : MonoBehaviour
{
    
    private float teleport_timer;
    public GameObject player;
    public GameObject bullet;
    public Transform bulletPos;
    private Health boss_health;
    
    public bool boss_p1;
    public bool boss_p2;
    public bool boss_p3;
    public bool boss_p4;
    public bool final_stand;

    public AudioClip tp_sfx;
    public AudioClip shoot_sfx;
    private AudioSource audioS;
    public GameObject popIN;
    private SpriteRenderer rend;


    private TransitionHandler tHandler;


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
        tHandler = GameObject.FindWithTag("TransitionHandler").GetComponent<TransitionHandler>();
        audioS = GetComponent<AudioSource>();
        rend = gameObject.GetComponentInChildren<SpriteRenderer>();
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
            popIN.SetActive(true);

        } else if (boss_p2 & boss_health.currentHealth <= 50) {
            boss_p3 = true;
            boss_p2 = false;
            popIN.SetActive(true);
        } else if (boss_p3 & boss_health.currentHealth <= 25) {
            boss_p4 = true;
            boss_p3 = false;
            popIN.SetActive(true);
        } else if (boss_p4 & boss_health.currentHealth <= 2) {
            boss_p4 = false;
            final_stand = true;
            popIN.SetActive(true);
            gameObject.transform.position = new Vector3 (22, -350, 0);
            StartCoroutine(finalStand());
        } else if (final_stand & boss_health.currentHealth <= 0) {
            final_stand = false;
            popIN.SetActive(true);
            tHandler.boss_dead = true;
            // Debug.Log("YOU WIN");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            boss_health.TakeDamage(2);
            Destroy(other.transform.gameObject);
            StartCoroutine(getHit());
        }

    }

    private IEnumerator getHit() {
        rend.color = new Color(2.55f, 0.3f, 2.55f, 1f);
        yield return new WaitForSeconds(0.2f);
        rend.color = new Color (2.55f, 2.55f, 2.55f, 1f);
    }


    private void boss_teleport() {
        float newx = player.transform.position.x;
        float newy = Random.Range(-341, -359);
        while (Mathf.Abs(newx - player.transform.position.x) < 9) {
            newx = Random.Range(4, 40);
            // Debug.Log("too close");
        }
        audioS.PlayOneShot(tp_sfx);
        gameObject.transform.position = new Vector3 (newx, newy, 0);
    }
    

    private IEnumerator shoot1()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private IEnumerator shoot2()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);


        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        
    }

    private IEnumerator shoot3()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);


        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private IEnumerator shoot4()
    {
        yield return new WaitForSeconds(0.5f);
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        
        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);

        audioS.PlayOneShot(shoot_sfx);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private IEnumerator finalStand() {
        float delay = 0.05f;
        while (boss_health.currentHealth > 0) {
            delay = delay * 2f;
            boss_teleport();
            yield return new WaitForSeconds(0.3f);
            audioS.PlayOneShot(shoot_sfx);
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
}
}


