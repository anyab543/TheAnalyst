using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene10aDialogue : MonoBehaviour
{
    public int primeInt = 1;         // This integer drives game progress!
    public Text Char1name;
    public Text Char1speech;
    public Text Char2name;
    public Text Char2speech;
    //public Text Char3name; 
    //public Text Char3speech;
    public GameObject DialogueDisplay;
    public GameObject ArtChar1a;
    //public GameObject ArtChar1b; 
    //public GameObject ArtChar2; 
    public GameObject ArtBG1;
    public GameObject Choice1a;
    public GameObject Choice1b;
    public GameObject NextScene1Button;
    public GameObject NextScene2Button;
    public GameObject nextButton;
    //public AudioSource audioSource;
    private bool allowSpace = true;

    // initial visibility settings. Any new images or buttons need to also be SetActive(false);
    void Start()
    {
        DialogueDisplay.SetActive(false);
        ArtChar1a.SetActive(false);
        ArtBG1.SetActive(true);
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        NextScene1Button.SetActive(false);
        NextScene2Button.SetActive(false);
        nextButton.SetActive(true);
    }

    void Update()
    {         // use spacebar as Next button
        if (allowSpace == true)
        {
            if (Input.GetKeyDown("space"))
            {
                next();
            }
        }
    }

    //Story Units! The main story function. Players hit [NEXT] to progress to the next primeInt:
    public void next()
    {
        primeInt = primeInt + 1;
        if (primeInt == 1)
        {
            // AudioSource.Play();
        }
        else if (primeInt == 2)
        {
            ArtChar1a.SetActive(true);
            DialogueDisplay.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "Who are you? Do you know what's going on?";
        }
        else if (primeInt == 3)
        {
            Char1name.text = "???";
            StartCoroutine(TypeText(Char1speech, "Don’t you remember me? I’m one of your patients. You’re helping me with my insomnia."));
            Char2name.text = "";
            Char2speech.text = "";
            //gameHandler.AddPlayerStat(1);
        }
        else if (primeInt == 4)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = ": I… I don’t remember.";
        }
        else if (primeInt == 5)
        {
            Char1name.text = "???";
            StartCoroutine(TypeText(Char1speech, "You remember. I’ve been having the nightmares about being lost in space. You’ve been helping me analyze my dreams so I can get better."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 6)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "I guess so. Something just seems strange. I’m really sure where to start.";
        }
        else if (primeInt == 7)
        {
            Char1name.text = "???";
            StartCoroutine(TypeText(Char1speech, "We can skip today’s session if you want. I’ve just been so stressed lately."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 8)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "No no it’s okay.";
        }


        // after choice 1a
        else if (primeInt == 9)
        {
            //gameHandler.AddPlayerStat(1); 
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            StartCoroutine(TypeText(Char2speech, "I just feel like I’m dreaming too. Haha."));
        }
        else if (primeInt == 10)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "Do you know what that something is?";

        }

        // after choice 1b
        else if (primeInt == 11)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "???";
            StartCoroutine(TypeText(Char2speech, "Haha well its like you say…"));
        }

        else if (primeInt == 12)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "???";
            StartCoroutine(TypeText(Char2speech, "The physical and psychical may be closer than what it appears to be."));
            nextButton.SetActive(false);
            allowSpace = false;
            NextScene2Button.SetActive(true);
        }

        //Please do NOT delete this final bracket that ends the next() function: 
    }

    // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)

    public void SceneChange1()
    {
        SceneManager.LoadScene("Scene10b");
    }
    public void SceneChange2()
    {
        SceneManager.LoadScene("Scene10b");
    }

    IEnumerator TypeText(Text target, string fullText)
    {
        float delay = 0.01f;
        nextButton.SetActive(false);
        allowSpace = false;
        for (int i = 0; i < fullText.Length; i++)
        {
            string currentText = fullText.Substring(0, i);
            target.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        nextButton.SetActive(true);
        allowSpace = true;
    }

}