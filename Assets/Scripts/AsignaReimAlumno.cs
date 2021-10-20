using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable]
public class AsignaInicio
{
    public string sesion_id;
    public int usuario_id;
    public int periodo_id;
    public int reim_id;
    public string datetime_inicio;
    public string datetime_termino;
    

}

public class AsignaReimAlumno : MonoBehaviour {
    public static string Session;
    public static int var = 0;
    //public int code;

    public void InsertInicio() {
        var = 1;
        AsignaInicio a;
        a = new AsignaInicio();
        Debug.Log("id_alumno = "+Conexiones.id_user);
        a.sesion_id = Conexiones.id_user + "-" +600+"-"+ System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        Session = a.sesion_id;
        a.usuario_id = int.Parse(Conexiones.id_user);
        a.periodo_id = 202101;
        a.reim_id = 600;
        a.datetime_inicio = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        a.datetime_termino = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        StartCoroutine(Post(a, "add"));
    } 

    public void UpdateARA()
    {
        AsignaInicio a;
        a = new AsignaInicio();
        a.datetime_termino = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //Debug.Log($"final/{Session}");
        StartCoroutine(Post(a, $"final/{Session}"));
    }

    void OnApplicationQuit()
    {
        UpdateARA();
    }

    void OnApplicationPause()
    {
        UpdateARA();
    }

    public IEnumerator Post(AsignaInicio a, string extend)  {
        string urlAPI = "http://localhost:3002/api/asigna_reim_alumno/" + extend;
        //Debug.Log("urlPI: "+urlAPI);

        var jsonData = JsonUtility.ToJson(a);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)) {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError) {
                Debug.Log(www.error);
                Debug.Log("error!");
            }
            else {
                if (www.isDone) {   
                    //Debug.Log("Se actualizo correctamente"+ extend);
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //Debug.Log(result);
                    if (result != null) {
                        if(extend == "add"){
                            //Debug.Log("Session: "+Session);
                            //Session = result;
                        }
                        //var asignaRA = JsonUtility.FromJson<AsignaInicio>(result);
                        //
                    }
                }
            }
        }
    }

    void Start()
    {
        if(var ==0 && SceneManager.GetActiveScene().buildIndex ==3){
            InsertInicio();
            
        }
        
        //if (code == 2)
        //{
            
        //}
    }


}
