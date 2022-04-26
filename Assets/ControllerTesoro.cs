using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class ControllerTesoro : MonoBehaviour
{
    public ShakeDemo shakedemo;
    public Button Bvolcan, Bfaro, Bcalavera, Btesoro;
    public GameObject Panel, PanelCorrecto,camino1,camino2,camino3;
    public Button Instruccion;
    public int pasosrandom,aux,pasosalumno;
    private int periodito = 202102;
    public UlearnCoins ulearnCoins;
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
                RegistraSaltoGanador1(ShakeDemo.pasos);
                Panel.SetActive(false);
                ShakeDemo.pasos = 0;
            }
        }
        else if (aux == 1)
        {
            if (ShakeDemo.pasos == pasosrandom) //VOLCAN
            {
                camino2.SetActive(true);
                aux += 1;
                Bcalavera.interactable = true;
                Bvolcan.interactable = false;
                RegistraSaltoGanador2(ShakeDemo.pasos);
                shakedemo.ResetShakeCount();
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
                camino2.SetActive(true);
                RegistraSaltoGanador3(ShakeDemo.pasos);
                shakedemo.ResetShakeCount();
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
            // GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(PanelRecompensas, PanelCorrecto);
            ulearnCoins.Ganar_UlearnCoins(500);
            PanelCorrecto.SetActive(true);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name);
            aux +=1;
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

	private void RegistraSaltoGanador1(int pasos){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3004;
        RespuestaBasura.id_elemento = 3096;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = 0;
        RespuestaBasura.Eje_Y = 0;
        RespuestaBasura.Eje_Z = 0;
        RespuestaBasura.correcta = 1;
        RespuestaBasura.resultado = "Primera instruccion correcta en el salto nro : " + pasos;
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }
    private void RegistraSaltoGanador2(int pasos){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3004;
        RespuestaBasura.id_elemento = 3096;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = 0;
        RespuestaBasura.Eje_Y = 0;
        RespuestaBasura.Eje_Z = 0;
        RespuestaBasura.correcta = 1;
        RespuestaBasura.resultado = "Segunda instruccion correcta en el salto nro : " + pasos;
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }
    private void RegistraSaltoGanador3(int pasos){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3004;
        RespuestaBasura.id_elemento = 3096;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = 0;
        RespuestaBasura.Eje_Y = 0;
        RespuestaBasura.Eje_Z = 0;
        RespuestaBasura.correcta = 1;
        RespuestaBasura.resultado = "Tercera instruccion correcta en el salto nro : " + pasos;
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }
}
