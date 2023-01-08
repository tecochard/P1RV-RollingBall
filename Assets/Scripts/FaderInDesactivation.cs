using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderInDesactivation : MonoBehaviour
{
    // Script to desactivate the FaderIn after 1 seconde
    private float temps;
    void Start()
    {
        temps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        temps += Time.deltaTime;
        if (temps >= 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
