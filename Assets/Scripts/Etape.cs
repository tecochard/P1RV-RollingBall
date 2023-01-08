using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etape : MonoBehaviour
{
    // Script for the intermediate step
    // for level 1.2
    public GameObject EndOfLevel;

    private void OnTriggerEnter(Collider other)
    {
        EndOfLevel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
