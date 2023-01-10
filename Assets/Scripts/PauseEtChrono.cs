using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PauseEtChrono : MonoBehaviour
{
    // Script to take a break, deal with the chrono
    // and restart the game if the player keeps he's finger pressed

    public GameObject MenuPause;
    public TextMeshProUGUI ChronoText;
    public GameObject Player;

    private Rigidbody rig_player;
    private Renderer r_player;
    private Material m_player;
    private Color c_player;
    private float color;
    private bool isPaused;
    private float temps;
    private float tempsRestart;
    public static float temps2f = 0;

    private bool hasStarted = false;
    private bool canStart = false;

    private void Start()
    {
        rig_player = Player.GetComponent<Rigidbody>();
        r_player = Player.GetComponent<Renderer>();
        m_player = r_player.material;
        c_player = m_player.color;
        temps = 0f;

        StartingPause();
    }

    private void StartingPause()
    {
        rig_player.isKinematic = true;
    }

    private void Pause()
    {
        // On met le jeu en pause
        isPaused = true;
        this.GetComponent<FollowGyro>().enabled = false;
        Time.timeScale = 0f;
        // Affiche le menu pause
        MenuPause.SetActive(true);        
    }

    void Update()
    {
        if (hasStarted)
        {
            // Pause
            if (Input.touchCount == 2)
            {
                Pause();
            }

            // Chrono
            if (!isPaused)
            {
                temps += Time.deltaTime;
            }

            // Restart
            if (!isPaused && !Collision.clignote)
            {
                if (Input.touchCount == 1)
                {
                    tempsRestart += Time.deltaTime;
                    // On change la couleur du joueur (sauf si sur les levels 2_2 et 2_3)
                    if (SceneManager.GetActiveScene().buildIndex != 7 && SceneManager.GetActiveScene().buildIndex != 6)
                    {
                        color = -Mathf.Pow(tempsRestart, 2) / 4 + 1;
                        m_player.SetColor("_Color", new Color(color, color, color, m_player.color.a));
                    }
                    // Et si le joueur maintient suffisament longtemps, alors on recharge la scène
                    if (tempsRestart > 1.5)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }

                }
                else
                {
                    tempsRestart = 0f;
                    if (SceneManager.GetActiveScene().buildIndex != 7)
                    {
                        m_player.SetColor("_Color", c_player);
                    }
                }
            }
            AfficheTemps();
        }
        else if (canStart && Input.touchCount == 1)
        {
            rig_player.isKinematic = false;
            temps = 0f;
            hasStarted = true;
        }
        else if (!canStart && Input.touchCount == 0)
        {
            canStart = true;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        MenuPause.SetActive(false);
        this.GetComponent<FollowGyro>().enabled = true;
        Time.timeScale = 1f;
    }
    
    private void AfficheTemps()
    {
        temps2f = (int) (temps * 100);
        temps2f = (float)temps2f / 100;
        ChronoText.text = "" + temps2f;
    }
}
