using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes2 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (SceneManager.GetActiveScene().name == "Scene10b")
            BGmusic.instance.GetComponent<AudioSource>().Pause();
        //BGMusic.instance.GetComponent<AudioSource>().Play();

    }
}
