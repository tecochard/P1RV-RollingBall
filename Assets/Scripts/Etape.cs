using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etape : MonoBehaviour
{
    // Script for the intermediate steps
    // for levels 1.2 and 2.1
    public GameObject EndOfLevel;

    private void OnTriggerEnter(Collider other)
    {
        EndOfLevel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
