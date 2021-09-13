using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class Tiempo
{
    public int id_tiempoactividad;
    public string inicio;
    public string final;
    public int causa;
    public int usuario_id;
    public int reim_id;
    public int actividad_id;
}

public class TiempoXActividad : MonoBehaviour
{
    // Start is called before the first frame update

    public string id_tiempoact;
    public int actividad;
    public string inicio_act;

    public IEnumerator PostAdd(Tiempo tiempito)
    {
        string urlAPI = "http://localhost:3002/api/tiempoxactividad/add";
        var jsonData = JsonUtility.ToJson(tiempito);
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
                        Debug.Log(result);
                        id_tiempoact = result;
                        //var id_txa = JsonUtility.FromJson<String>(result);
                        //Debug.Log(id_txa);
                    }
                }
            }
        }
    }

    public void iniciartiempo()
    {
        Tiempo act_tempo;
        act_tempo = new Tiempo();
        act_tempo.actividad_id = actividad;
        act_tempo.causa = 0;
        DateTime ahora = DateTime.Now;
        act_tempo.final= ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        act_tempo.inicio= ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        inicio_act = act_tempo.inicio;
        act_tempo.reim_id = 500;
        act_tempo.usuario_id = int.Parse(Conexiones.id_user);
        StartCoroutine(PostAdd(act_tempo));
    }

    public IEnumerator PostEnd(Tiempo tiempito)
    {
        string urlAPI = "http://localhost:3002/api/tiempoxactividad/update/" + tiempito.id_tiempoactividad.ToString();
        var jsonData = JsonUtility.ToJson(tiempito);
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
            }
            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null)
                    {
                        Debug.Log(result);
                        
                    }
                }
            }
        }
    }

    public void TerminoActividad()
    {
        Tiempo act_tempo1;
        act_tempo1 = new Tiempo();
        act_tempo1.id_tiempoactividad = int.Parse(id_tiempoact);
        act_tempo1.actividad_id = actividad;
        act_tempo1.causa = 0;
        //DateTime ahora = DateTime.Now;
        act_tempo1.final = (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        act_tempo1.inicio = inicio_act;
        act_tempo1.reim_id = 500;
        act_tempo1.usuario_id = int.Parse(Conexiones.id_user);
        StartCoroutine(PostEnd(act_tempo1));
    }

    public IEnumerator PostInt(Tiempo tiempito)
    {
        string urlAPI = "http://localhost:3002/api/tiempoxactividad/update/" + tiempito.id_tiempoactividad.ToString();
        var jsonData = JsonUtility.ToJson(tiempito);
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
            }
            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null)
                    {
                        Debug.Log(result);

                    }
                }
            }
        }
    }

    public void Actividadinter()
    {
        Tiempo act_tempo1;
        act_tempo1 = new Tiempo();
        act_tempo1.id_tiempoactividad = int.Parse(id_tiempoact);
        act_tempo1.actividad_id = actividad;
        act_tempo1.causa = 1;
        //DateTime ahora = DateTime.Now;
        act_tempo1.final = (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        act_tempo1.inicio = inicio_act;
        act_tempo1.reim_id = 500;
        act_tempo1.usuario_id = int.Parse(Conexiones.id_user);
        StartCoroutine(PostEnd(act_tempo1));
    }

    void Start()
    {
        iniciartiempo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
