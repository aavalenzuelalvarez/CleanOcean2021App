using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
public class AlumnoRespLabBasura : MonoBehaviour
{
    private GameObject Objeto;
    public int periodito = 202102;
    private int elementito;
    private int actividadsita;
    private int correctita;
    private float ejesitox;
    private float ejesitoy;
    private float ejesitoz;
    // public GameObject prueba;

    



    void Start()
    {
        Objeto = this.gameObject;
        periodito = 202102;
        actividadsita = 3003;
        // Debug.Log(this.gameObject.GetComponent<testbutton>());
        // this.gameObject.GetComponent<AlumnoRespLabBasura>().unEventoLab.AddListener(delegate { test(this.gameObject.name); });
        // unEventoLab.AddListener(delegate{test();});
    }
    

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown(){
        Debug.Log(Objeto);
        if (Objeto.name == "Basura Vaso"){
            elementito = 3040;
        }else if(Objeto.name == "Basura Bolsa"){
            elementito = 3041;
        }else if(Objeto.name == "Basura Leche"){
            elementito = 3095;
        }else if(Objeto.name == "Basura Botella Azul"){
            elementito = 3095;
        }else if(Objeto.name == "Basura Barril"){
            elementito = 3019;
        }
        ejesitox = Objeto.transform.position.x;
        ejesitoy = Objeto.transform.position.y;
        ejesitoz = Objeto.transform.position.z;
        Debug.Log("ID DE ESTE OBJETO : " + elementito +" : " + ejesitox + " " + ejesitoy + " " + ejesitoz);

        Touchsito();
    }
    public IEnumerator PostAdd(Respuesta respueston)
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

    public void Touchsito()
    {
        Respuesta respuestini;
        respuestini = new Respuesta();
        respuestini.id_per = periodito;
        respuestini.id_user = int.Parse(Conexiones.id_user);
        respuestini.id_reim = 500;
        respuestini.id_actividad = actividadsita;
        respuestini.id_elemento = elementito;
        DateTime ahora = DateTime.Now;
        respuestini.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        respuestini.Eje_X = ejesitox;
        respuestini.Eje_Y = ejesitoy;
        respuestini.Eje_Z = ejesitoz;
        respuestini.correcta = 2;
        respuestini.resultado = "No Aplica";
        respuestini.Tipo_Registro = 0;
        StartCoroutine(PostAdd(respuestini));
    }


}
