using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pauseb : MonoBehaviour
{
    public GameObject  pause, ButtonPause, PanelPausa;
    public GameObject[] Botones;
    public int i;

    // Start is called before the first frame update

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if (SceneManager.GetActiveScene().name == "Actividad Patrones")
        {
            PanelPausa.SetActive(true);
            Time.timeScale = 0;
            OcultarBotones();
        }
        else{
            Time.timeScale = 0;
            PanelPausa.SetActive(true);
            OcultarBotones();
            GameObject.Find("AudioManager").GetComponent<AudioSource>().volume = 0.1f;
        }
        
    }

    // Update is called once per frame
    public void Resume()
    {
        if (SceneManager.GetActiveScene().name == "Actividad Patrones")
        {
            PanelPausa.SetActive(false);
            Time.timeScale = 1;
            MostrarBotones();
        }
        else{
            Time.timeScale = 1;
            PanelPausa.SetActive(false);
            MostrarBotones();
            GameObject.Find("AudioManager").GetComponent<AudioSource>().volume = 1f;
        }
        
    }

    public void OcultarBotones()
    {
        for (i = 0; i <= Botones.Length - 1; i++)
        {
            Botones[i].SetActive(false);
        }
    }

    public void MostrarBotones()
    {
        for (i = 0; i <= Botones.Length - 1; i++)
        {
            Botones[i].SetActive(true);
        }
    }
}
