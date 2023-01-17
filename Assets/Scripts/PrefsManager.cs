using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    // Script to initialise and deal with all the PlayerPrefs
    private float _2StarsTimer;
    private float _3StarsTimer; 

    // Start is called before the first frame update
    void Start()
    {
        /*SetTimers();
        SetNumberOfStars();

        // Initialisation de tous les parametres joueurs lors du 1er lancement du jeu 
        if (!PlayerPrefs.HasKey("Initialised"))
        {
            ResetMusicChoice();
            ResetProgression();
            ResetScore();
            ResetNumberOfStars();
        }

        PlayerPrefs.SetInt("Initialised", 1);*/

        // - FOR THE DEMO -
        PlayerPrefs.SetInt("levelProgression", 10);
        PlayerPrefs.SetInt("numberOfStars", 30);
    }

    public void ResetMusicChoice()
    {
        // 1=oui, 0=non
        PlayerPrefs.SetInt("musicChill", 1);
    }
    
    public void MusicChill()
    {
        PlayerPrefs.SetInt("musicChill", 1);
    }

    public void MusicHard()
    {
        PlayerPrefs.SetInt("musicChill", 0);
    }

    // Reset the level progression
    public void ResetProgression()
    {
        PlayerPrefs.SetInt("levelProgression", 2); //Scene2 = level 1_1
        ResetScore();
        ResetNumberOfStars();
    }

    // Reset the scores
    public void ResetScore()
    {
        // Reset tous les timers à -1
        for (int i=0; i < 11; i++)
        {
            PlayerPrefs.SetFloat("timerLevel" + i, -1);
        }
    }

    public void ResetNumberOfStars()
    {
        PlayerPrefs.SetInt("numberOfStars", 0);
    }

    private void SetTimers()
    {
        for (int i=2; i<11; i++)
        {
            switch (i)
            {
                case 2:
                    _2StarsTimer = 7;
                    _3StarsTimer = 3.60f;
                    break;

                case 3:
                    _2StarsTimer = 10;
                    _3StarsTimer = 6.14f;
                    break;

                case 4:
                    _2StarsTimer = 20;
                    _3StarsTimer = 10.62f;
                    break;

                case 5:
                    _2StarsTimer = 16;
                    _3StarsTimer = 15.29f;
                    break;

                case 6:
                    _2StarsTimer = 40;
                    _3StarsTimer = 25;
                    break;

                case 7:
                    _2StarsTimer = 35;
                    _3StarsTimer = 30;
                    break;

                case 8:
                    _2StarsTimer = 10;
                    _3StarsTimer = 9.65f;
                    break;

                case 9:
                    _2StarsTimer = 7;
                    _3StarsTimer = 5.5f;
                    break;

                case 10:
                    _2StarsTimer = 30;
                    _3StarsTimer = 15;
                    break;

            }

            PlayerPrefs.SetFloat("timer2stars" + i, _2StarsTimer);
            PlayerPrefs.SetFloat("timer3stars" + i, _3StarsTimer);
        }
    }

    public static void SetNumberOfStars()
    {
        float MeilleurTemps;
        int _nbOfStarsAdded;
        // On initialise le nombre total d'étoiles
        PlayerPrefs.SetInt("numberOfStars", 0);

        for (int i =2; i<11; i++)
        {
            // Get the best time for this level
            MeilleurTemps = PlayerPrefs.GetFloat("timerLevel" + i);

            // Get the number of stars to add
            if (MeilleurTemps < PlayerPrefs.GetFloat("timer3stars" + i) && MeilleurTemps >0)
            {
                _nbOfStarsAdded = 3;
            }
            else if (MeilleurTemps < PlayerPrefs.GetFloat("timer2stars" + i) && MeilleurTemps > 0)
            {
                _nbOfStarsAdded = 2;
            }
            else if (MeilleurTemps > 0)
            {
                _nbOfStarsAdded = 1;
            }
            else { _nbOfStarsAdded = 0; }

            // Add it to the number total of stars
            PlayerPrefs.SetInt("numberOfStars", PlayerPrefs.GetInt("numberOfStars") + _nbOfStarsAdded);
        }
    }

    // Choose the orientation of the screen on the phone
    public void SetScreenLeft()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void SetScreenRight()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }
}
