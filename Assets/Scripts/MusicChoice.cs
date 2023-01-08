using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChoice : MonoBehaviour
{
    // Script to register the choice of music of the player
    public AudioSource easy;
    public AudioSource hard;

    void Start()
    {
        if (PlayerPrefs.GetInt("musicChill") == 1)
        {
            easy.Play();            
        }
        else
        {
            hard.Play();
        }
    }
}
