using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controlador_DragNDrop : MonoBehaviour
{
    public Text[] Operaciones;
    public Text[] Digitos;
    public static GameObject a, b, c, d;
    public GameObject[] Animales, Ocultar;
    public GameObject Panel_recompensa, Panel_correcto, Panel_incorrecto, Botonvolver, Botonpausa;
    public int x, i, y;
    public Text Respuesta1, Respuesta2;
    private int numero1, numero2, numero3, numero4, operador1, operador2, aux = 0;
    public static int respuesta1, respuesta2;
    public string Resp1, Resp2;
    public int numResp1, numResp2;
    public string[] tagsToDisable =
            {
                     "Caracol",
                     "Estrella",
                     "Erizo",
                     "Cangrejo"
                 };
    // Start is called before the first frame update
    void Start()
    {
        for (i = 0; i < Operaciones.Length; i++)
        {
            x = Random.Range(0, 2);
            if (x == 0)
            {
                Operaciones[i].text = "+";
            }
            else if (x == 1)
            {
                Operaciones[i].text = "-";
            }


        }
        for (i = 0; i < Digitos.Length; i++)
        {

            if (i == 1 || i == 3)
            {
                y = int.Parse(Digitos[i - 1].text);
                x = Random.Range(0, y);
                Digitos[i].text = x.ToString();
            }
            else
            {
                x = Random.Range(1, 10);
                Digitos[i].text = x.ToString();
            }
        }

        for (i = 0; i < 2; i++)
        {

            if (i == 0)
            {
                x = Random.Range(0, 4);
                a = Instantiate(Animales[x]);
                b = Instantiate(Animales[x]);
                a.gameObject.SetActive(true);
                b.gameObject.SetActive(true);
                if (a.name == "Ammonite_prefab(Clone)")
                {
                    a.transform.position = new Vector3(-58.3f, 37.6f, 69.6f);
                    b.transform.position = new Vector3(-20.6f, 37.6f, 69.6f);
                }
                else if (a.name == "Crab_prefab(Clone)")
                {
                    a.transform.position = new Vector3(-51.1f, 35.8f, 69.6f);
                    b.transform.position = new Vector3(-12.3f, 35.8f, 69.6f);
                }
                else
                {
                    a.transform.position = new Vector3(-60.1f, 42.8f, 85.9f);
                    b.transform.position = new Vector3(-12.3f, 42.8f, 85.9f);
                }
            }

            if (i == 1)
            {
                y = Random.Range(0, 4);
                while (y == x)
                {
                    y = Random.Range(0, 4);
                }
                c = Instantiate(Animales[y]);
                d = Instantiate(Animales[y]);
                c.gameObject.SetActive(true);
                d.gameObject.SetActive(true);
                if (c.name == "Ammonite_prefab(Clone)")
                {
                    c.transform.position = new Vector3(19f, 37.4f, 69.6f);
                    d.transform.position = new Vector3(53f, 37.4f, 69.6f);
                }
                else if (c.name == "Crab_prefab(Clone)")
                {
                    c.transform.position = new Vector3(26f, 35.8f, 69.6f);
                    d.transform.position = new Vector3(60f, 35.8f, 69.6f);
                }
                else
                {
                    c.transform.position = new Vector3(26f, 36.4f, 69.6f);
                    d.transform.position = new Vector3(60f, 36.4f, 69.6f);
                }
            }
        }

        numero1 = int.Parse(Digitos[0].text);
        numero2 = int.Parse(Digitos[1].text);
        numero3 = int.Parse(Digitos[2].text);
        numero4 = int.Parse(Digitos[3].text);

        for (i = 0; i < Operaciones.Length; i++)
        {
            if (Operaciones[i].text == "-")
            {
                if (i == 0)
                {
                    respuesta1 = numero1 - numero2;
                }
                if (i == 1)
                {
                    respuesta2 = numero3 - numero4;
                }
            }
            if (Operaciones[i].text == "+")
            {
                if (i == 0)
                {
                    respuesta1 = numero1 + numero2;
                }
                if (i == 1)
                {
                    respuesta2 = numero3 + numero4;
                }
            }
        }
        print(respuesta1);
        print(respuesta2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Respuesta1.text != "")
        {
            numResp1=(int.Parse(Respuesta1.text));
        }
        if (Respuesta2.text != "")
        {
            numResp2 = (int.Parse(Respuesta2.text));
        }
            //Resp1 = (Respuesta1.text);
            //Resp2 = (Respuesta2.text);
            //int numResp1 = int.Parse(Resp1);
            //int numResp2 = int.Parse(Resp2);

            //if (Piezas_DragAndDrop.final == 2 && aux == 0)
            if ( Respuesta1.text== respuesta1.ToString() &&  Respuesta2.text== respuesta2.ToString() && aux==0)
        {
            GameObject.Find("Shark").SetActive(false);

            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Ocultar");
            GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag("Pieza");
            GameObject[] gameObjectArray3 = GameObject.FindGameObjectsWithTag("Cangrejo");
            GameObject[] gameObjectArray4 = GameObject.FindGameObjectsWithTag("Estrella");
            GameObject[] gameObjectArray5 = GameObject.FindGameObjectsWithTag("Caracol");
            GameObject[] gameObjectArray6 = GameObject.FindGameObjectsWithTag("Erizo");

            foreach (GameObject go in gameObjectArray)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in gameObjectArray2)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in gameObjectArray3)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in gameObjectArray4)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in gameObjectArray5)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in gameObjectArray6)
            {
                go.SetActive(false);
            }
            GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name);
            GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(Panel_recompensa, Panel_correcto);
            aux += 1;
            //Piezas_DragAndDrop.final = 0;
        }
        else if (numResp1 > respuesta1 || numResp2 > respuesta2)
        {
            //Piezas_DragAndDrop.final = 0;
            Botonvolver.SetActive(false);
            Botonpausa.SetActive(false);
            GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(Panel_incorrecto);
            GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name);
        }
    }
}
