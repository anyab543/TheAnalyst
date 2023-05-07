using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_GlobalLight2 : MonoBehaviour{
 
    public UnityEngine.Rendering.Universal.Light2D myGlobalLight;
    private PulseCoolDown gHandler;
    private bool is_active;
 
    void Start(){
        myGlobalLight = gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        myGlobalLight.intensity = 0.5f;
        is_active = false;
        gHandler = GameObject.FindWithTag("cooldownHandler").GetComponent<PulseCoolDown>();
    }

    void Update(){
        if (Input.GetKeyDown("e") & gHandler.pulse_charges > 0 & !is_active){
            
            myGlobalLight.intensity = 1f;
            gHandler.pulse_charges--;
            is_active = true;
            StartCoroutine(LightsDown());

        }
    }

    IEnumerator LightsDown(){
        
        yield return new WaitForSeconds(0.5f);
        for (float i=1f; i>0.5f; i -= 0.1f){
            myGlobalLight.intensity = i;
            yield return new WaitForSeconds(0.05f);
        }
        myGlobalLight.intensity = 0.5f;
        is_active = false;
    }

}
