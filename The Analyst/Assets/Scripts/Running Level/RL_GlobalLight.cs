using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_GlobalLight : MonoBehaviour{
 
    public UnityEngine.Rendering.Universal.Light2D myGlobalLight;
 
    void Start(){
        myGlobalLight = gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        myGlobalLight.intensity = 0.05f;
    }

    void Update(){
        if (Input.GetKeyDown("e")){
            myGlobalLight.intensity = 1f;
            StartCoroutine(LightsDown());
        }
    }

    IEnumerator LightsDown(){
        yield return new WaitForSeconds(0.5f);
        for (float i=1f; i>0.05f; i -= 0.01f){
            myGlobalLight.intensity = i;
        }
        myGlobalLight.intensity = 0f;
    }

}
