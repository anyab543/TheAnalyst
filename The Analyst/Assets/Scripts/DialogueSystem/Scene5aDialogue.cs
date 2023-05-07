using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene5aDialogue : MonoBehaviour
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
            Char2speech.text = "Who are you?";
        }
        else if (primeInt == 3)
        {
            Char1name.text = "???";
            Char1speech.text = "*sobs*";
            Char2name.text = "";
            Char2speech.text = "";
            //gameHandler.AddPlayerStat(1);
        }
        else if (primeInt == 4)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "Hello? Are you okay?";
        }
        else if (primeInt == 5)
        {
            Char1name.text = "???";
            Char1speech.text = "Doctor? Is that you? Thanks for seeing me today.";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 6)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "Um… Yes of course. What’s been troubling you?";
        }
        else if (primeInt == 7)
        {
            Char1name.text = "???";
            Char1speech.text = "Well, I’ve been having this reoccurring nightmare.";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 8)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "Okay. Walk me through this dream.";
        }


        // after choice 1a
        else if (primeInt == 9)
        {
            //gameHandler.AddPlayerStat(1); 
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "???";
            Char2speech.text = "I’m in this random hall or street. Everything is dark. The dream always starts with me running and the feeling that something is behind me.";
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
            Char2speech.text = "No… but it feels familiar. ";
        }

        else if (primeInt == 12)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "???";
            Char2speech.text = "Whatever or whoever it is... its energy is heavy... Do you feel it too?";
        }

        else if (primeInt == 13)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "I'm not sure I understand.";
        }

        else if (primeInt == 14)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "*Your eyes start to feel heavy*";
        }

        else if (primeInt == 15)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "???";
            Char2speech.text = "Please help me doctor! It’s in this building. I can feel it.";
        }

        else if (primeInt == 16)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Analyst";
            Char2speech.text = "*You close your eyes and collapse*";
            nextButton.SetActive(false);
            allowSpace = false;
            NextScene2Button.SetActive(true);
        }

        else if (primeInt == 31)
        {
            Char1name.text = "Analyst";
            Char1speech.text = "Ragu hangs out in a rough part of town. I'll take you now.";
            Char2name.text = "";
            Char2speech.text = "";
            nextButton.SetActive(false);
            allowSpace = false;
            NextScene2Button.SetActive(true);
        }

        //Please do NOT delete this final bracket that ends the next() function: 
    }

    // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
    
    public void SceneChange1()
    {
        SceneManager.LoadScene("Scene2a");
    }
    public void SceneChange2()
    {
        SceneManager.LoadScene("Scene5b");
    }
}