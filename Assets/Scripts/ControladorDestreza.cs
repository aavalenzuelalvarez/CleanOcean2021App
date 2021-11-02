using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDestreza : MonoBehaviour
{
    
    public ActividadDestreza BasuraPrefab;
    public ActividadDestreza BasuraPrefab1;
    public ActividadDestreza BasuraPrefab2;
    public ActividadDestreza BasuraPrefab3;
    public ActividadDestreza BasuraPrefab4;
    public ActividadDestreza BasuraPrefab5;
    public ActividadDestreza BasuraPrefab6;
    public UlearnCoins ulearnCoins;
    private int aux = 0;
    public GameObject PanelIncorrecto, PanelCorrecto;
    private float tiempo = 40f;
    public Text contador;
    public Text time;

    void Start()
    {
        contador.text = "" + tiempo;
        time.enabled = false;
    }

    // Update is called once per frame
    void Update()

    {
        if (tiempo > 0)
        {
            tiempo -= Time.deltaTime;
            contador.text = "" + tiempo.ToString("f0");
        }

        if (tiempo <= 0 && aux == 0)
        {
            aux +=1;
            contador.text = "0";
            time.enabled = true;
            //PanelIncorrecto.SetActive(true);
            //GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(PanelIncorrecto);
            // GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(PanelIncorrecto);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name);
            PanelIncorrecto.SetActive(true);
            ulearnCoins.Ganar_UlearnCoins(250);
            movimientoB.speed = 5;
        }
        else if(tiempo > 0)
        {
            movimientoB.speed = 0;
        }

        if (BasuraPrefab.encendida == false && BasuraPrefab1.encendida == false && BasuraPrefab2.encendida == false && BasuraPrefab3.encendida == false && BasuraPrefab4.encendida == false && BasuraPrefab5.encendida == false && BasuraPrefab6.encendida == false && aux==0)
        {
            aux += 1;
            //PanelCorrecto.SetActive(true);
            // GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(PanelRecompensas, PanelCorrecto);
            PanelCorrecto.SetActive(true);
            ulearnCoins.Ganar_UlearnCoins(500);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name);
            // Invoke("ocultarobjetos", 3f);
            movimientoB.speed = 5;
            //Invoke("MostrarRecompensa", 3f);
        }
        
    }
    //private void MostrarRecompensa()
    //{
    //    PanelCorrecto.gameObject.SetActive(false);
    //    GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(PanelRecompensas, PanelCorrecto);
    //}
    //private void ReiniciarAct()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
    public void ocultarobjetos()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Ocultar");

        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
           // movimientoB.speed = 0;
        }

    }
}
