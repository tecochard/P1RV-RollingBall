using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelLocked : MonoBehaviour
{
    // Script to block access to the next world if not enough stars

    private int nbOfStarsNeeded;
    private int starsForNextWorld;

    private string NextLevelText;
    public Button NextLevelButton;

    private void Start()
    {
        NextLevelText = NextLevelButton.GetComponentInChildren<TextMeshProUGUI>().text;

        // If the player has finished the level 2.1
        // then it means that he needs to unlock the
        // world 3 and not the world 2 anymore
        if (PlayerPrefs.GetInt("levelProgression") < 6)
        {
            starsForNextWorld = 6;
        }
        else
        {
            starsForNextWorld = 13;
        }
    }


    void Update()
    {
        nbOfStarsNeeded = starsForNextWorld - PlayerPrefs.GetInt("numberOfStars");
        if (nbOfStarsNeeded == 1)
        {
            NextLevelButton.interactable = false;
            NextLevelButton.GetComponentInChildren<TextMeshProUGUI>().text = "You need " + nbOfStarsNeeded + " more star";
        }
        else if (nbOfStarsNeeded > 1)
        {
            NextLevelButton.interactable = false;
            NextLevelButton.GetComponentInChildren<TextMeshProUGUI>().text = "You need " + nbOfStarsNeeded + " more stars";
        }
        else
        {
            NextLevelButton.interactable = true;
            NextLevelButton.GetComponentInChildren<TextMeshProUGUI>().text = NextLevelText;
        }
    }
}
