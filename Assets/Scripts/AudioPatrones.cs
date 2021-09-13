using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioPatrones : MonoBehaviour
{
    public AudioSource fuente;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reproducir()
    {
        fuente.clip = clip;
        fuente.Play();
        // if (SceneManager.GetActiveScene().name == "Progreso")
        // {
        //     GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.1f;
        //     Invoke("SubirMusica", fuente.clip.length);
        // }
        // else
        // {
        //     //GameObject.Find("AudioManager").GetComponent<AudioSource>().volume = 0.1f;
        //     Invoke("SubirMusica", fuente.clip.length);
        // }
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
