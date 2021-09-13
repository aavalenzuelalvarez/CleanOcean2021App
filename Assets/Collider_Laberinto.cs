using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collider_Laberinto : MonoBehaviour
{
    public Material Skybox;
    public GameObject Panel_correcto, Panel_incorrecto, Panel_recompensa;
    public int aux;
    // Start is called before the first frame update
    void Start()
    {
        aux = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "Petroleo actLab" && aux==0)
        {
            GetComponent<movimientoF>().enabled = false;
            print(col.gameObject.name);
            GameObject.Find("Game").SetActive(false);
            GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name, col.gameObject.name);
            GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(Panel_incorrecto);
            aux += 1;
        }
        else if ((col.gameObject.name == "RocaE" || col.gameObject.name == "Faro actLab" || col.gameObject.name == "Isla actLab") && aux==0 )
        {
            Invoke("ocultarwaves", 4f);
            GameObject.Find("Main Camera").GetComponent<Skybox>().enabled = false;
            GetComponent<movimientoF>().enabled = false;
            print(col.gameObject.name);
            GameObject.Find("Game").SetActive(false);
            GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name, col.gameObject.name);
            RenderSettings.skybox = Skybox;
            GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(Panel_recompensa, Panel_correcto);
            aux += 1;
        }
        else if (col.gameObject.name == "Muralla Invisible" || col.gameObject.tag == "Basura" || col.gameObject.name == "Muralla invisible" || col.gameObject.name == "Muralla invisible")
        {
            GameObject.Find("Conexiones").GetComponent<Conexiones>().Colision(SceneManager.GetActiveScene().name);
        }

    }
    void ocultarwaves()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Ocultar");
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
        //GameObject.Find("Agua").SetActive(false);
    }

}
