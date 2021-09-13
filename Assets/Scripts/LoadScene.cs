using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public GameObject[] actividades;

    

    void Start()
    {
        actividades = GameObject.FindGameObjectsWithTag("Actividades");
        
        
    }

    public void SceneLoader(int Scene)
    {
        SceneManager.LoadScene(Scene);
        

    }
    public void QuitGame()
    {
        Debug.Log("SALIR");
        Application.Quit();

    }

    public void CargarActividad()
    {
        //Debug.Log(Conexiones.id_actividad);
        if(Conexiones.id_actividad.Equals("1"))
        {
            SceneManager.LoadScene(3);
        }
        if(Conexiones.id_actividad.Equals("2"))
        {
            SceneManager.LoadScene(5);
        }
        if (Conexiones.id_actividad.Equals("3"))
        {
            SceneManager.LoadScene("Progreso");
        }
        if (Conexiones.id_actividad.Equals("4"))
        {
            SceneManager.LoadScene(9);
        }
    }

    public void CargarLaberinto()
    {
        int[] labs = { 6, 12, 13};
        SceneManager.LoadScene(labs[Random.Range(0,3)]);
    }


}
