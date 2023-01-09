using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 Offset;

    void Start()
    {
        Offset =  this.transform.position - Player.transform.position;
    }

    
    void Update()
    {
        this.transform.position = Player.transform.position + Offset;
    }
}
