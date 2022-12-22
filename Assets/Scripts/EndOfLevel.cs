using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    [SerializeField] GameObject GyroController;
    [SerializeField] GameObject Fader;
    [SerializeField] GameObject EndMenu;
    [SerializeField] TextMeshProUGUI ChronoText;
    [SerializeField] GameObject HighScoreText;

    public AudioSource FinishSound;

    private float meilleurTemps;

    private void Start()
    {
        meilleurTemps = PlayerPrefs.GetFloat("timerLevel" + SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter()
    {
        // On coupe le jeu et on affiche le EndMenu
        GyroController.SetActive(false);
        Fader.SetActive(true);
        EndMenu.SetActive(true);
        Debug.Log("niveau fini");

        // Joue le son de victoire
        FinishSound.Play();

        // Si c'est un meilleur temps, on enregistre le chrono
        if (PauseEtChrono.temps2f < meilleurTemps || meilleurTemps < 0f)
        {
            PlayerPrefs.SetFloat("timerLevel" + SceneManager.GetActiveScene().buildIndex, PauseEtChrono.temps2f);
            HighScoreText.SetActive(true);
        }
        // On affiche le score sur le EndMenu
        ChronoText.text = "" + PauseEtChrono.temps2f;

        // Enregistrement de la progression des niveaux
        if(PlayerPrefs.GetInt("levelProgression") <= SceneManager.GetActiveScene().buildIndex)
        {
            // On donne acc�s au niveau n+1
            PlayerPrefs.SetInt("levelProgression", SceneManager.GetActiveScene().buildIndex +1);
        }
    }
}
