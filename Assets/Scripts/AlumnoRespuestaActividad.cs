using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class Respuesta
{
    public int id_per;
    public int id_user;
    public int id_reim;
    public int id_actividad;
    public int id_elemento;
    public string datetime_touch;
    public float Eje_X;
    public float Eje_Y;
    public float Eje_Z;
    public int correcta;
    public string resultado;
    public int Tipo_Registro;
}

public class AlumnoRespuestaActividad : MonoBehaviour
{
    public int periodito = 202102;
    public static int elementito;
    public int actividadsita;
    public static int correctita;
    public static float ejesitox;
    public static float ejesitoy;
    public static float ejesitoz;
    // public GameObject prueba;

    public IEnumerator PostAdd(Respuesta respueston)
    {
        string urlAPI = "http://localhost:3002/api/alumno_respuesta/add";
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

    public void SetElemento(string elementoide){
        elementito = int.Parse(elementoide);
        ejesitox = gameObject.transform.position.x;
        ejesitoy = gameObject.transform.position.y;
        ejesitoz = gameObject.transform.position.z;
    }

    public void SetCorrecto(string correctoide){
        correctita = int.Parse(correctoide);
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
        respuestini.correcta = correctita;
        respuestini.resultado = "No Aplica";
        respuestini.Tipo_Registro = 0;
        StartCoroutine(PostAdd(respuestini));
    }

    // public void SetCorrectoPanel(){
    //     Respuesta respuestacorrecta;
    //     respuestacorrecta = new Respuesta();
    //     respuestacorrecta.id_per = periodito;
    //     respuestacorrecta.id_user = int.Parse(Conexiones.id_user);
    //     respuestacorrecta.id_reim = 500;
    //     respuestacorrecta.id_actividad = 3007;
    //     respuestacorrecta.id_elemento = 3059;
    //     DateTime ahora = DateTime.Now;
    //     respuestacorrecta.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
    //     respuestacorrecta.Eje_X = gameObject.transform.position.x;
    //     respuestacorrecta.Eje_Y = gameObject.transform.position.y;
    //     respuestacorrecta.Eje_Z = 0;
    //     respuestacorrecta.correcta = 1;
    //     respuestacorrecta.resultado = "Correcto";
    //     respuestacorrecta.Tipo_Registro = 0;
    //     StartCoroutine(PostAdd(respuestacorrecta));
    // }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
