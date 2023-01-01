using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class World2Locked : MonoBehaviour
{
    private int nbOfStarsNeeded;
    public TextMeshProUGUI TextStarsNeeded;
    public Button Level1;
    public Button Level2;
    public Button Level3;

    // Start is called before the first frame update
    void Update()
    {
        if (this.gameObject.name == "PanelWorld2Locked")
        {
            // Show the number of stars needed for World2
            nbOfStarsNeeded = 6 - PlayerPrefs.GetInt("numberOfStars");

            Debug.Log(nbOfStarsNeeded);

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
            // Show the number of stars needed for World2
            nbOfStarsNeeded = 12 - PlayerPrefs.GetInt("numberOfStars");

            Debug.Log(nbOfStarsNeeded);

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
