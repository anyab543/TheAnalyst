using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DreamerReappear : MonoBehaviour
{
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {
        yPos = -375f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (yPos < -350f) {
            yPos += 0.05f;
        } else {
            SceneManager.LoadScene("EndWin");
        }
        gameObject.transform.position = new Vector3 (30, yPos, 0);
    }
}
