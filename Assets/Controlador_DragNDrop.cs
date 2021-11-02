using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Controlador_DragNDrop : MonoBehaviour
{
    public Text[] Operaciones;
    public Text[] Digitos;
    public static GameObject a, b, c, d;
    public GameObject[] Animales, Ocultar;
    public GameObject Panel_correcto, Panel_incorrecto, Botonvolver, Botonpausa, TextResult1, TextResult2;
    public GameObject TiendaUlearnet;
    public UlearnCoins ulearnCoins;
    public int x, i, y;
    public Text Respuesta1, Respuesta2;
    private int numero1, numero2, numero3, numero4, operador1, operador2, aux = 0;
    public static int respuesta1, respuesta2;
    public string Resp1, Resp2;
    public int numResp1, numResp2;
    private int cont;
    private int elemento1;
    private int elemento2;
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
        cont = 0;
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
                    TextResult1.GetComponent<Text>().text = numero1 + " - " + numero2 + " = " + respuesta1;
                }
                if (i == 1)
                {
                    respuesta2 = numero3 - numero4;
                    TextResult2.GetComponent<Text>().text = numero3 + " - " + numero4 + " = " + respuesta2;
                }
            }
            if (Operaciones[i].text == "+")
            {
                if (i == 0)
                {
                    respuesta1 = numero1 + numero2;
                    TextResult1.GetComponent<Text>().text = numero1 + " + " + numero2 + " = " + respuesta1;
                }
                if (i == 1)
                {
                    respuesta2 = numero3 + numero4;
                    TextResult2.GetComponent<Text>().text = numero3 + " + " + numero4 + " = " + respuesta2;
                }
            }
        }

        print(respuesta1);
        print(respuesta2);
        Debug.Log("este es el A : " + a.name);
        if (a.name == "Ammonite_prefab(Clone)"){
            elemento1 = 3064;
        }else if (a.name == "Sea_urchin_prefab(Clone)"){
            elemento1 = 3062;
        }else if (a.name == "Crab_prefab(Clone)"){
            elemento1 = 3063;
        }else if (a.name == "Starfish_v1_prefab (1)(Clone)"){
            elemento1 = 3061;
            Debug.Log("Elemento1 estrella");
        }
        Debug.Log("Este es el C : " + c.name);
        if (c.name == "Ammonite_prefab(Clone)"){
            elemento2 = 3064;
        }else if (c.name == "Sea_urchin_prefab(Clone)"){
            elemento2 = 3062;
        }else if (c.name == "Crab_prefab(Clone)"){
            elemento2 = 3063;
        }else if (c.name == "Starfish_v1_prefab (1)(Clone)"){
            elemento2 = 3061;
            Debug.Log("Elemento2 estrella");
        }
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
            if ( Respuesta1.text == respuesta1.ToString() &&  Respuesta2.text == respuesta2.ToString() && aux==0)
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
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name);
            // GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(Panel_recompensa, Panel_correcto);
            Panel_correcto.SetActive(true);
            TiendaUlearnet.SetActive(true);
            ulearnCoins.Ganar_UlearnCoins(500);
            RespuestaFinalCorrecta(elemento1);
            Debug.Log("Se registra el elemento1 final");
            RespuestaFinalCorrecta(elemento2);
            Debug.Log("Se registra el elemento2 final");
            
            aux += 1;
            //Piezas_DragAndDrop.final = 0;
        }
        else if (numResp1 > respuesta1 && cont == 0 || numResp2 > respuesta2 && cont == 0)
        {

            GameObject.Find("Shark").SetActive(false);
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Ocultar");
            GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag("Pieza");
            GameObject[] gameObjectArray3 = GameObject.FindGameObjectsWithTag("Cangrejo");
            GameObject[] gameObjectArray4 = GameObject.FindGameObjectsWithTag("Estrella");
            GameObject[] gameObjectArray5 = GameObject.FindGameObjectsWithTag("Caracol");
            GameObject[] gameObjectArray6 = GameObject.FindGameObjectsWithTag("Erizo");
            // foreach (GameObject go in gameObjectArray)
            // {
            //     go.SetActive(false);
            // }
            // foreach (GameObject go in gameObjectArray2)
            // {
            //     go.SetActive(false);
            // }
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
            //Piezas_DragAndDrop.final = 0;
            Botonvolver.SetActive(false);
            Botonpausa.SetActive(false);
            // GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(Panel_incorrecto);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name);
            Panel_incorrecto.SetActive(true);
            TiendaUlearnet.SetActive(true);
            ulearnCoins.Ganar_UlearnCoins(250);
            cont = cont + 1;
            Debug.Log(cont);
            RespuestaFinalIncorrecto(elemento1);
            Debug.Log("Se registra la respuesta incorrecta 1");
            RespuestaFinalIncorrecto(elemento2);
            Debug.Log("Se registra la respuesta incorrecta 2");
        }
    }

    public void RespuestaFinalCorrecta(int elemento1){
        Respuesta respuestacorrecta = new Respuesta();
        respuestacorrecta.id_per = 202102;
        respuestacorrecta.id_user = int.Parse(Conexiones.id_user);
        respuestacorrecta.id_reim = 500;
        respuestacorrecta.id_actividad = 3005;
        respuestacorrecta.id_elemento = elemento1;
        System.DateTime ahora = System.DateTime.Now;
        respuestacorrecta.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        respuestacorrecta.Eje_X = gameObject.transform.position.x;
        respuestacorrecta.Eje_Y = gameObject.transform.position.y;
        respuestacorrecta.Eje_Z = 0;
        respuestacorrecta.correcta = 1;
        respuestacorrecta.resultado = "Calculo correcto";
        respuestacorrecta.Tipo_Registro = 0;
        StartCoroutine(PostAddRespuestaDrag(respuestacorrecta));
    }
    public void RespuestaFinalIncorrecto(int elemento1){
        Respuesta respuestacorrecta = new Respuesta();
        respuestacorrecta.id_per = 202102;
        respuestacorrecta.id_user = int.Parse(Conexiones.id_user);
        respuestacorrecta.id_reim = 500;
        respuestacorrecta.id_actividad = 3005;
        respuestacorrecta.id_elemento = elemento1;
        System.DateTime ahora = System.DateTime.Now;
        respuestacorrecta.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        respuestacorrecta.Eje_X = gameObject.transform.position.x;
        respuestacorrecta.Eje_Y = gameObject.transform.position.y;
        respuestacorrecta.Eje_Z = 0;
        respuestacorrecta.correcta = 0;
        respuestacorrecta.resultado = "Calculo incorrecto";
        respuestacorrecta.Tipo_Registro = 0;
        StartCoroutine(PostAddRespuestaDrag(respuestacorrecta));
    }


    public IEnumerator PostAddRespuestaDrag(Respuesta respueston)
    {
        string urlAPI = cambiarApiServidor.URL + "/alumno_respuesta/add"; //"http://localhost:3002/api/alumno_respuesta/add";
        var jsonData = JsonUtility.ToJson(respueston);
        //Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                Debug.Log("Error");
            }
            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null)
                    {
                        //var id_txa = JsonUtility.FromJson<String>(result);
                        //Debug.Log(id_txa);
                    }
                }
            }
        }
    }
}
