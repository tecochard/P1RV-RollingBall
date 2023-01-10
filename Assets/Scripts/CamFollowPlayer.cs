using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 Offset;
    private Vector3 newPos;
    private float altitude;

    void Start()
    {
        Offset =  this.transform.position - Player.transform.position;
        altitude = this.transform.position.y;
    }

    
    void Update()
    {
        newPos = Player.transform.position + Offset;
        newPos.y = altitude;
        this.transform.position = newPos;
    }
}
