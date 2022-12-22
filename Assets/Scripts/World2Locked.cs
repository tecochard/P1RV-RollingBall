using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class World2Locked : MonoBehaviour
{
    private int nbOfStarsNeeded;
    public TextMeshProUGUI TextStarsNeeded;
    public Button Level4;
    public Button Level5;
    public Button Level6;

    // Start is called before the first frame update
    void Update()
    {
        // Show the number of stars needed for World2
        nbOfStarsNeeded = 6 - PlayerPrefs.GetInt("numberOfStars");

        Debug.Log(nbOfStarsNeeded);

        if (nbOfStarsNeeded > 0)
        {
            TextStarsNeeded.text = "X " + nbOfStarsNeeded;
            Level4.interactable = false;
            Level5.interactable = false;
            Level6.interactable = false;
        }
        else
        {
            this.gameObject.SetActive(false);
            Level4.interactable = true;
            Level5.interactable = true;
            Level6.interactable = true;
        }
    }
}
