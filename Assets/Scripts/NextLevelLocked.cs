using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelLocked : MonoBehaviour
{
    //Block access to the World2 at the end of the level 1.3 if not enough stars

    private int nbOfStarsNeeded;

    private string NextLevelText;
    public Button NextLevelButton;

    private void Start()
    {
        NextLevelText = NextLevelButton.GetComponentInChildren<TextMeshProUGUI>().text;
    }

    // Update is called once per frame
    void Update()
    {
        nbOfStarsNeeded = 6 - PlayerPrefs.GetInt("numberOfStars");
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
