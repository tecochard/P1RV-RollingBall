using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtapeS : MonoBehaviour
{
    // Script to manage the color of the several steps of the level 2.1
    public GameObject Door;
    public GameObject NextDoor;
    public GameObject NextEtape;

    private void OnTriggerEnter(Collider other)
    {
        // change la couleur des portes
        Door.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        NextDoor.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        // (des)active les etapes
        this.gameObject.SetActive(false);
        NextEtape.SetActive(true);
    }
}
