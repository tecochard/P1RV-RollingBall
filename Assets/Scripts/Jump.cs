using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Script to make the ball jump when the screen is touched
    // in world 3

    private Rigidbody m_playerRig;
    public GameObject Gyroscope;
    //parametres
    private float distToGround;
    public float jumpForce;
    private bool jumping = false;



    // Start is called before the first frame update
    void Start()
    {
        m_playerRig = GetComponent<Rigidbody>();
        distToGround = 0.51f; //boule de rayon 0.5
    }

    //Fonction pour savoir si l'on touche le sol
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Gyroscope.transform.up, distToGround);
    }


    IEnumerator Wait(float seconds)
    {
        m_playerRig.AddForce(Gyroscope.transform.up * jumpForce);
        yield return new WaitForSeconds(seconds);
        jumping = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        // Saut
        if (Input.touchCount == 1 && IsGrounded() && !jumping)
        {
            jumping = true;
            StartCoroutine(Wait(0.5f));
        }
    }
}
