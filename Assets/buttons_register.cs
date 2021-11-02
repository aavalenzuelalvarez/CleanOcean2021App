// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class buttons_register : MonoBehaviour
// {
//     private string id_elemento, id_actividad;

//     // Start is called before the first frame update
//     void Start()
//     {
//         if (SceneManager.GetActiveScene().name == "Progreso")
//         {
//             id_actividad = 3000.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Tesoro")
//         {
//             id_actividad = 3005.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Drag And Drop")
//         {
//             id_actividad = 3006.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Laberinto")
//         {
//             id_actividad = 3004.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Lancha")
//         {
//             id_actividad = 3002.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad suma")
//         {
//             id_actividad = 3003.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "MainMenu")
//         {
//             id_actividad = 3001.ToString();
//         }
//         else if (SceneManager.GetActiveScene().name == "Actividad Destreza")
//         {
//             id_actividad = 3007.ToString();
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void BotonPlay()
//     {
//         id_elemento = "3000";
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetActividad(id_actividad);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetElemento(id_elemento);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().Boton();
//     }

//     public void BotonAtras()
//     {
//         id_elemento = "3001";
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetActividad(id_actividad);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetElemento(id_elemento);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().Boton();
//     }

//     public void BotonAvanzar()
//     {
//         id_elemento = "3002";
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetActividad(id_actividad);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetElemento(id_elemento);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().Boton();
//     }

//     public void BotonPausa()
//     {
//         id_elemento = "3008";
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetActividad(id_actividad);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetElemento(id_elemento);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().Boton();
//     }

//     public void BotonInstruccionestxt()
//     {
//         id_elemento = "3067";
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetActividad(id_actividad);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetElemento(id_elemento);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().Boton();
//     }
//     public void BotonInstruccionesaud()
//     {
//         id_elemento = "3013";
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetActividad(id_actividad);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetElemento(id_elemento);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().Boton();
//     }

//     public void BotonReinicio()
//     {
//         id_elemento = "3009";
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetActividad(id_actividad);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetElemento(id_elemento);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().Boton();
//     }

//     public void BotonMusica()
//     {
//         id_elemento = "3007";
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetActividad(id_actividad);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().SetElemento(id_elemento);
//         GameObject.Find("Conexiones").GetComponent<Conexiones>().Boton();


//     }


// }
