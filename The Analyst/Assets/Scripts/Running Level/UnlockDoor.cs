using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour{

      public string NextLevel = "EndWin";

      public void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Player"){
                  SceneManager.LoadScene(NextLevel);
            }
      }

}
