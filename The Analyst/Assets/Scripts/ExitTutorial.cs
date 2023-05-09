using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTutorial : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene("RunningLevel");
    }

}
