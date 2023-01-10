using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldLocked : MonoBehaviour
{
    // Script to deal with the World2 and World3 pannels when locked
    // shows the number of stars still needed to unlock the world
    private int nbOfStarsNeeded;
    public TextMeshProUGUI TextStarsNeeded;
    public Button Level1;
    public Button Level2;
    public Button Level3;

    void Update()
    {
        if (this.gameObject.name == "PanelWorld2Locked")
        {
            // Show the number of stars needed for World2
            nbOfStarsNeeded = 6 - PlayerPrefs.GetInt("numberOfStars");

            if (nbOfStarsNeeded > 0)
            {
                TextStarsNeeded.text = "X " + nbOfStarsNeeded;
                Level1.interactable = false;
                Level2.interactable = false;
                Level3.interactable = false;
            }
            else
            {
                this.gameObject.SetActive(false);
                Level1.interactable = true;
                Level2.interactable = true;
                Level3.interactable = true;
            }
        }

        if (this.gameObject.name == "PanelWorld3Locked")
        {
            // Show the number of stars needed for World3
            nbOfStarsNeeded = 12 - PlayerPrefs.GetInt("numberOfStars");

            if (nbOfStarsNeeded > 0)
            {
                TextStarsNeeded.text = "X " + nbOfStarsNeeded;
                Level1.interactable = false;
                Level2.interactable = false;
                Level3.interactable = false;
            }
            else
            {
                this.gameObject.SetActive(false);
                Level1.interactable = true;
                Level2.interactable = true;
                Level3.interactable = true;
            }
        }
    }
}
