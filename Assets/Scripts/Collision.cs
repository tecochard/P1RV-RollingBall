using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Joueur")]
    [SerializeField] private GameObject Player;
    [SerializeField] GameObject GyroController;

    private Rigidbody rig_player;
    static public bool hasFallen;
    static public bool clignote;

    private Color m_playerColor;


    private Vector3 _playerPosDepart;

    private Vector3 _gyroPosDepart;
    private Quaternion _gyroRotDepart;

    void Start()
    {
        //Player
        _playerPosDepart = Player.transform.localPosition;
        rig_player = Player.GetComponent<Rigidbody>();
        //Gyroscope
        _gyroPosDepart = GyroController.transform.position;
        _gyroRotDepart = GyroController.transform.rotation;
        //Couleur
        m_playerColor = Player.GetComponent<Renderer>().material.color;
    }

    IEnumerator Clignoter()
    {
        for (int i=0; i<3; i++)
        {
            var Renderer = Player.GetComponent<Renderer>();
            m_playerColor.a = 0.5f;
            Renderer.material.SetColor("_Color", m_playerColor);
            yield return new WaitForSeconds(0.3f);
            m_playerColor.a = 1.0f;
            Renderer.material.SetColor("_Color", m_playerColor); 
            yield return new WaitForSeconds(0.3f);

        }
        clignote = false;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        print("collision");
        /*// On remet le plateau a plat
        GyroController.transform.SetPositionAndRotation(_gyroPosDepart, _gyroRotDepart);
        // Desactive le gyrocontroller
        GyroController.GetComponent<FollowGyro>().enabled = false;*/

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
            /* // On reactive le gyrocontroller
             GyroController.GetComponent<FollowGyro>().enabled = true;*/

            // On laisse la boule bouger
            rig_player.isKinematic = false;
            hasFallen = false;
        }
    }
}
