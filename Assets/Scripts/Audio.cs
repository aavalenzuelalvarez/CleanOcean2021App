using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public AudioSource fuente;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        fuente.clip = clip;
    }

    // Update is called once per frame
    public void Reproducir()
    {
        fuente.Play();
        if (SceneManager.GetActiveScene().name == "Progreso")
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.1f;
            Invoke("SubirMusica", fuente.clip.length);
        }
        else
        {
            //GameObject.Find("AudioManager").GetComponent<AudioSource>().volume = 0.1f;
            Invoke("SubirMusica", fuente.clip.length);
        }
    }
    public void SubirMusica()
    {
        if (SceneManager.GetActiveScene().name == "Progreso")
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 1f;
        }
        else
        {
            GameObject.Find("AudioManager").GetComponent<AudioSource>().volume = 1f;
        }

    }
}

