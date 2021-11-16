using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

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
    private int periodito = 202102;
    public Text contador;
    public Text time;
    private float ejesitox, ejesitoy, ejesitoz;

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
            SetElementoFinal();
            RegistrarIncorrecta();
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
            SetElementoFinal();
            RegistrarCorrecta();
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name);
            // Invoke("ocultarobjetos", 3f);
            movimientoB.speed = 5;
            //Invoke("MostrarRecompensa", 3f);
        }
        
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
    private void SetElementoFinal(){
        ejesitox = gameObject.transform.position.x;
        ejesitoy = gameObject.transform.position.y;
        ejesitoz = gameObject.transform.position.z;
        Debug.Log(ejesitox + " " + ejesitoy + " " + ejesitoz);
    }
    private void RegistrarCorrecta(){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3006;
        RespuestaBasura.id_elemento = 3099;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 1;
        RespuestaBasura.resultado = "Toda basura arriba del barco";
        Debug.Log(RespuestaBasura.resultado);
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }
    private void RegistrarIncorrecta(){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3006;
        RespuestaBasura.id_elemento = 3099;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 0;
        RespuestaBasura.resultado = "Falta basura que subir";
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
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
