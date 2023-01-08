using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{
    // Script to show the right amount of stars for each level in the PlayMenu

    public Sprite Star0; // jamais fini
    public Sprite Star1; // niveau fini
    public Sprite Star2; // niveau fini assez vite
    public Sprite Star3; // niveau fini très vite

    private string Pannel;
    private int numLevel;
    private float MeilleurTemps;

    private float _2StarsTimer;
    private float _3StarsTimer;

    void Start()
    {
        // Get the number of the level
        Pannel = transform.parent.name;
        int.TryParse(Pannel, out numLevel);
        numLevel++;
    }

    private void Update()
    {
        // Get the best time for this level
        MeilleurTemps = PlayerPrefs.GetFloat("timerLevel" + numLevel);

        // Get the time needed for the stars depending on the level
        _2StarsTimer = PlayerPrefs.GetFloat("timer2stars" + numLevel);
        _3StarsTimer = PlayerPrefs.GetFloat("timer3stars" + numLevel);

        // Give the good sprite
        if (MeilleurTemps < _3StarsTimer && MeilleurTemps > 0)
        {
            this.GetComponent<Image>().sprite = Star3;
        }
        else if (MeilleurTemps < _2StarsTimer && MeilleurTemps > 0)
        {
            this.GetComponent<Image>().sprite = Star2;
        }
        else if (MeilleurTemps > 0)
        {
            this.GetComponent<Image>().sprite = Star1;
        }
        else
        {
            this.GetComponent<Image>().sprite = Star0;
        }
    }
}
