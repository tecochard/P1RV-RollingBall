using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockPlayMenu : MonoBehaviour
{
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public Button Level4;
    public Button Level5;
    public Button Level6;

    public Button Return;
    public Button Tutorial;
    public Button HighScores;

    public AudioSource Nononon;

    // Update is called once per frame
    void Update()
    {
        if (Nononon.isPlaying)
        {
            Level1.interactable = false;
            Level2.interactable = false;
            Level3.interactable = false;
            Level4.interactable = false;
            Level5.interactable = false;
            Level6.interactable = false;
            Return.interactable = false;
            Tutorial.interactable = false;
            HighScores.interactable = false;
        }
        else
        {
            Level1.interactable = true;
            Level2.interactable = true;
            Level3.interactable = true;
            Level4.interactable = true;
            Level5.interactable = true;
            Level6.interactable = true;
            Return.interactable = true;
            Tutorial.interactable = true;
            HighScores.interactable = true;
        }
    }
}
