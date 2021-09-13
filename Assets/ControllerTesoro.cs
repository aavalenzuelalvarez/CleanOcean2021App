using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerTesoro : MonoBehaviour
{
    public ShakeDemo shakedemo;
    public Button Bvolcan, Bfaro, Bcalavera, Btesoro;
    public GameObject Panel, PanelCorrecto,camino1,camino2,camino3, PanelRecompensas;
    public Button Instruccion;
    public int pasosrandom,aux,pasosalumno;
    // Start is called before the first frame update
    void Start()
    {
        Bvolcan.interactable = false;
        Bcalavera.interactable = false;
        aux = 0;
        pasosrandom = 100;
        shakedemo = this.GetComponent<ShakeDemo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aux == 0)
        {

            if (ShakeDemo.pasos == pasosrandom) //FARO
            {
                aux += 1;
                camino1.SetActive(true);
                Bvolcan.interactable = true;
                Bfaro.interactable = false;
                Panel.SetActive(false);
                ShakeDemo.pasos = 0;
            }
        }
        else if (aux == 1)
        {
            if (ShakeDemo.pasos == pasosrandom) //VOLCAN
            {
                shakedemo.ResetShakeCount();
                camino2.SetActive(true);
                aux += 1;
                Bcalavera.interactable = true;
                Bvolcan.interactable = false;
                Panel.SetActive(false);
                ShakeDemo.pasos = 0;
            }
        }
        else if (aux == 2)
        {
            if (ShakeDemo.pasos == pasosrandom) //CALAVERA
            {
                Bcalavera.interactable = false;
                Btesoro.interactable = true;
                shakedemo.ResetShakeCount();
                camino2.SetActive(true);
                Panel.SetActive(false);
                aux += 1;
            }
        }
        else if (aux == 3)
        {

            //PanelCorrecto.SetActive(true);
        }
    }

    public void FaroPress()
    {
        if (aux == 0)
        {
            Panel.SetActive(true);
            pasosrandom = Random.Range(2, 15);
            shakedemo.ResetShakeCount();
            Instruccion.GetComponentInChildren<Text>().text= "Da " + pasosrandom + " saltos para activar volcán";
        }

    }
    public void VolcanPress()
    {
        if (aux == 1)
        {

            shakedemo.ResetShakeCount();
            Panel.SetActive(true);
            pasosrandom = Random.Range(2, 15);
            Instruccion.GetComponentInChildren<Text>().text = "Da " + pasosrandom + " saltos para activar calavera";
        }
    }
    public void CalaveraPress()
    {
        if (aux == 2)
        {
            shakedemo.ResetShakeCount();
            Panel.SetActive(true);
            pasosrandom = Random.Range(2, 15);
            Instruccion.GetComponentInChildren<Text>().text = "Da " + pasosrandom + " saltos para ganar tu recompensa";
        }
    }
    public void TesoroPress()
    {
        if (aux == 3)
        {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Ocultar");

            foreach (GameObject go in gameObjectArray)
            {
                go.SetActive(false);
            }
            GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(PanelRecompensas, PanelCorrecto);
            GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name);
            aux +=1;
        }
    }

}
