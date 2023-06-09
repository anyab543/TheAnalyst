using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timeBetweenFiring;
    private AudioSource shoot_sound;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        shoot_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);


        if (Input.GetMouseButton(0) && canFire) {
            canFire = false;
            shoot_sound.Play();
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            StartCoroutine(WaitForShoot());
        }
    }

    IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(timeBetweenFiring);
        canFire = true;
    }
}
