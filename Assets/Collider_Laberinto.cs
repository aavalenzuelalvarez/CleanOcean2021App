using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Collider_Laberinto : MonoBehaviour
{
    public Material Skybox;
    public GameObject Panel_correcto, Panel_incorrecto;
    public int aux;
    public UlearnCoins ulearnCoins;
    private float ejesitox;
    private float ejesitoy;
    private float ejesitoz;
    public int periodito = 202102;

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
            SetElementoFinal(col.gameObject);
            RegistraBasuraIncorrecta(3049);
            ulearnCoins.Ganar_UlearnCoins(250);
            GameObject.Find("Game").SetActive(false);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name, col.gameObject.name);
            // GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(Panel_incorrecto);
            Panel_incorrecto.SetActive(true);
            aux += 1;
        }
        else if ((col.gameObject.name == "RocaE") && aux==0 )
        {
            Invoke("ocultarwaves", 4f);
            GameObject.Find("Main Camera").GetComponent<Skybox>().enabled = false;
            GetComponent<movimientoF>().enabled = false;
            print(col.gameObject.name);
            SetElementoFinal(col.gameObject);
            RegistraBasuraCorrecta(3052, "Elefante Marino actLab");
            ulearnCoins.Ganar_UlearnCoins(500);
            GameObject.Find("Game").SetActive(false);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name, col.gameObject.name);
            RenderSettings.skybox = Skybox;
            Panel_correcto.SetActive(true);
            // GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(Panel_recompensa, Panel_correcto);
            aux += 1;
        }
        else if ((col.gameObject.name == "Faro actLab") && aux==0 )
        {
            Invoke("ocultarwaves", 4f);
            GameObject.Find("Main Camera").GetComponent<Skybox>().enabled = false;
            GetComponent<movimientoF>().enabled = false;
            print(col.gameObject.name);
            SetElementoFinal(col.gameObject);
            RegistraBasuraCorrecta(3051, "Faro actLab");
            ulearnCoins.Ganar_UlearnCoins(500);
            GameObject.Find("Game").SetActive(false);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name, col.gameObject.name);
            RenderSettings.skybox = Skybox;
            Panel_correcto.SetActive(true);
            // GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(Panel_recompensa, Panel_correcto);
            aux += 1;
        }
        else if ((col.gameObject.name == "Isla actLab") && aux==0 )
        {
            Invoke("ocultarwaves", 4f);
            GameObject.Find("Main Camera").GetComponent<Skybox>().enabled = false;
            GetComponent<movimientoF>().enabled = false;
            print(col.gameObject.name);
            SetElementoFinal(col.gameObject);
            RegistraBasuraCorrecta(3050, "Isla actLab");
            ulearnCoins.Ganar_UlearnCoins(500);
            GameObject.Find("Game").SetActive(false);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name, col.gameObject.name);
            RenderSettings.skybox = Skybox;
            Panel_correcto.SetActive(true);
            // GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(Panel_recompensa, Panel_correcto);
            aux += 1;
        }
        else if(col.gameObject.tag == "PuntoLab"){
            SetElementoFinal(col.gameObject);
            RegistraColisionGeneral(3094, "PuntoLab");
            Debug.Log(col.gameObject.name);
            ulearnCoins.Ganar_UlearnCoins(50);
            col.gameObject.SetActive(false);
        }
        else if (col.gameObject.name == "Basura Vaso")
        {
            SetElementoFinal(col.gameObject);
            RegistraColisionGeneral(3040, "Basura Vaso");
        }
        else if (col.gameObject.name == "Basura Bolsa"){
            SetElementoFinal(col.gameObject);
            RegistraColisionGeneral(3041, "Basura Bolsa");
        }
        else if (col.gameObject.name == "Basura Botella azul"){
            SetElementoFinal(col.gameObject);
            RegistraColisionGeneral(3042, "Basura Botella azul");
        }else if (col.gameObject.name == "Basura Leche"){
            SetElementoFinal(col.gameObject);
            RegistraColisionGeneral(3095, "Basura Leche");
        }

        // else if (col.gameObject.name == "Muralla Invisible" || col.gameObject.tag == "Basura" || col.gameObject.name == "Muralla invisible" || col.gameObject.name == "Muralla invisible")
        // {
        //     GameObject.Find("Conexiones").GetComponent<Conexiones>().Colision(SceneManager.GetActiveScene().name);
        // }

    }
    private IEnumerator PostAdd(Respuesta respueston)
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
    private void SetElementoFinal(GameObject colision){
        ejesitox = colision.transform.position.x;
        ejesitoy = colision.transform.position.y;
        ejesitoz = colision.transform.position.z;
        Debug.Log(ejesitox + " " + ejesitoy + " " + ejesitoz);
    }
    private void RegistraBasuraCorrecta(int elementito, string nombrecolision){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3003;
        RespuestaBasura.id_elemento = elementito;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 1;
        RespuestaBasura.resultado = "Respuesta Correcta en : " + nombrecolision;
        Debug.Log(RespuestaBasura.resultado);
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }
    private void RegistraBasuraIncorrecta(int elementito){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3003;
        RespuestaBasura.id_elemento = elementito;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 0;
        RespuestaBasura.resultado = "Salida de petroleo";
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }

    private void RegistraColisionGeneral(int elementito, string nombrecolision){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3003;
        RespuestaBasura.id_elemento = elementito;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 2;
        RespuestaBasura.resultado = "Choque con : " + nombrecolision;
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
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
