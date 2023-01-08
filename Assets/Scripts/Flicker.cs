using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    // Script to apply the flickering effect when the textures swap
    // in the levels 2.2 and 2.3
    public GameObject Player;
    public Material PlayerText;
    public Material LevelText;
    public Material Transparent; // texture pour faire clignoter les objets
    public Material InvisibleText;

    private Color m_playerColor;
    private Color m_levelColor;

    private bool _echange = false;

    private bool _playerVisible = true; // true = player visible; false = level visible

    private void Start()
    {
        m_playerColor = Player.GetComponent<Renderer>().material.color;
        m_levelColor = this.gameObject.GetComponent<Renderer>().material.color;
    }

    IEnumerator Clignoter()
    {
        var m_playerRenderer = Player.GetComponent<Renderer>();
        var m_levelRenderer = this.gameObject.GetComponent<Renderer>();
        _echange = true;

        // Pour que l'on voit le plateau et le joueur clignoter,
        // il faut leur donner les textures transparentes (pas opaques)
        m_playerRenderer.material = Transparent;
        m_levelRenderer.material = Transparent;

        // On fait clignoter le player et le level
        for (int i = 0; i < 3; i++)
        {
            m_playerColor.a = 0.5f;
            m_levelColor.a = 0.25f;
            m_playerRenderer.material.SetColor("_Color", m_playerColor);
            m_levelRenderer.material.SetColor("_Color", m_levelColor);
            yield return new WaitForSeconds(0.3f);

            m_playerColor.a = 1.0f;
            m_levelColor.a = 0.5f;
            m_playerRenderer.material.SetColor("_Color", m_playerColor);
            m_levelRenderer.material.SetColor("_Color", m_levelColor);
            yield return new WaitForSeconds(0.3f);
        }

        _playerVisible = !_playerVisible;
        // Et on donne leur texture finale
        switch (_playerVisible) 
        { 
            case true:
                m_playerRenderer.material = PlayerText;
                m_levelRenderer.material = InvisibleText;
                break;
            case false:
                m_playerRenderer.material = InvisibleText;
                m_levelRenderer.material = LevelText;
                break;
        }

        yield return new WaitForSeconds(1f);
        _echange = false;
    }

    void Update()
    {
        if (Collision.hasFallen == false && !_echange && !Collision.clignote && Input.touchCount > 0)
        {
            StartCoroutine(Clignoter());
        }
    }
}