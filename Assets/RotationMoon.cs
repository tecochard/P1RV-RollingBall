using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMoon : MonoBehaviour
{
    public int speedRotation;
    // Script to rotate the Moon on the lvl 3.1
    // at speedRotation (angle/s)
    void Update()
    {
        transform.Rotate( Vector3.up * speedRotation * Time.deltaTime );
    }
}
