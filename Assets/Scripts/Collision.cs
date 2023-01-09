using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Script for when the ball falls off the bord
    // Attached to every sides of the Bounds prefab

    [Header("Joueur")]
    public GameObject Player;
    public GameObject GyroController;
    public Material PlayerMaterial;
    public Material FallenMaterial;

    private Rigidbody rig_player;
    static public bool hasFallen;
    static public bool clignote;

    private Material oldMaterial;
    private Renderer m_playerRenderer;
    private Color m_playerColor;
    private Vector3 _playerPosDepart;

    void Start()
    {
        // Physic
        _playerPosDepart = Player.transform.localPosition;
        rig_player = Player.GetComponent<Rigidbody>();

        // Renderer
        m_playerRenderer = Player.GetComponent<Renderer>();
    }

    IEnumerator Clignoter()
    {
        for (int i=0; i<3; i++)
        {
            m_playerColor = Player.GetComponent<Renderer>().material.color;
            m_playerColor.a = 0.5f;
            m_playerRenderer.material.SetColor("_Color", m_playerColor);
            yield return new WaitForSeconds(0.3f);
            m_playerColor.a = 1.0f;
            m_playerRenderer.material.SetColor("_Color", m_playerColor); 
            yield return new WaitForSeconds(0.3f);

        }
        clignote = false;

        // and reset the texture
        m_playerRenderer.material = oldMaterial;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        print("collision");

        // Get the current texture of the ball
        oldMaterial = m_playerRenderer.material;

        Debug.Log(oldMaterial.name);
        // Give a different texture to show that the ball is not moving
        m_playerRenderer.material = FallenMaterial;

        // On remet le joueur au debut du niveau et sans vitesse;
        Player.transform.localPosition = _playerPosDepart;
        Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        // La boule ne bouge plus mais on peut encore bouger le plateau
        rig_player.isKinematic = true;
        hasFallen = true;

        // et on fait clignoter la boule
        clignote = true;
        StartCoroutine(Clignoter());
    }

    void Update()
    {        
        if (hasFallen == true && Input.touchCount > 0)
        {
            // If player touchs the screen, we let the ball move again
            rig_player.isKinematic = false;
            hasFallen = false;


        }     
    }
}
