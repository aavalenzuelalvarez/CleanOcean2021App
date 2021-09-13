using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorpanelprogreso : MonoBehaviour
{
    public static int panel = 1;
    public GameObject Panelinicio, Slider, Avanzar, Volver, Audio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (panel == 1)
        {
            Panelinicio.SetActive(true);
            Slider.SetActive(false);
            Audio.SetActive(false);
            Avanzar.SetActive(false);
            Volver.SetActive(false);
        }
        else
        {
            Panelinicio.SetActive(false);
            Slider.SetActive(true);
            Avanzar.SetActive(true);
            Audio.SetActive(true);
            Volver.SetActive(true);
        }
    }

    public void Cambiarpanel(int numero)
    {
        panel=numero;
    }
}
