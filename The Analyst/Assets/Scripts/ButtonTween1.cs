using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTween1 : MonoBehaviour{
	public AnimationCurve curveScale = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    public AnimationCurve curveAlpha = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
	float elapsed = 0f;
    float elapsedMove = 0f;
	Vector3 startScale;
    Image thisImage;
    public GameObject buttonText;

    public bool isButton1 = false;
    bool doButton1 = false;
    public bool isButton2 = false;
    bool doButton2 = false;
    public bool isButton3 = false;
    bool doButton3 = false;

    float timer = 0;
    float button1Timer = 0.5f;
    float button2Timer = 1.5f;
    float button3Timer = 2f;

    float buttonYstart;
    float preOffsetPos;
    float startOffset = 100f;
    Vector3 startButtonPos;

    void Awake(){
        buttonYstart = transform.position.y;
        startScale = transform.localScale;
        thisImage = GetComponent<Image>();
    }

	void Start(){
        preOffsetPos = transform.position.y;
        startButtonPos = transform.position;
        startButtonPos.y += startOffset;
        transform.position = startButtonPos;
        
        thisImage.color = new Color(2.55f, 2.55f, 2.55f, 0f);
        buttonText.GetComponent<TextMeshProUGUI>().color = new Color(2.55f, 2.55f, 2.55f, 0f);
	}

	void FixedUpdate () {
        timer += Time.deltaTime;
        if (timer >= button1Timer){doButton1=true;}
        if (timer >= button2Timer){doButton2=true;}
        if (timer >= button3Timer){doButton3=true;}

        if (
            ((isButton1)&&(doButton1)) 
            || ((isButton2)&&(doButton2))
            || ((isButton3)&&(doButton3))
        ){
            //position
            if (startButtonPos.y >= preOffsetPos){
                startButtonPos.y -= curveScale.Evaluate(elapsedMove) * startOffset;
                transform.position = startButtonPos;
            }

            //scale
		    //transform.localScale = startScale * curveScale.Evaluate(elapsed);

            //alpha
            if (elapsed <= 1f){
                float newAlpha = curveAlpha.Evaluate(elapsed);
                thisImage.color = new Color(2.55f, 2.55f, 2.55f, newAlpha);
                buttonText.GetComponent<TextMeshProUGUI>().color = new Color(2.55f, 2.55f, 2.55f, newAlpha);
            }
		    elapsed += Time.deltaTime;
            elapsedMove += (Time.deltaTime/10);
        }
	}
}