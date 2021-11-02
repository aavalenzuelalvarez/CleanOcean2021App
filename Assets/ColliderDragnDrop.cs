using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ColliderDragnDrop : MonoBehaviour
{
    public GameObject Father;
    private int ejesitox;
    private int ejesitoy;
    private int ejesitoz;
    private int periodito = 202102;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Shark" || col.gameObject.name == "Muralla invisible") //|| col.gameObject.name == "Reset1" || col.gameObject.name == "Reset2")
        {
            RegistraColisionGeneral(3022, "Tiburon DnD");
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().Colision(SceneManager.GetActiveScene().name);
            Father.GetComponent<Piezas_DragAndDrop>().placed = true;
            if (this.gameObject.name == "CuboRespuesta1")
            {
                Father.transform.position = new Vector3(-63.7f,-37.5f,96.6f);
            }
            else if (this.gameObject.name == "CuboRespuesta2")
            {
                Father.transform.position = new Vector3(-15.9f, -37.5f, 96.9f);
            }
            else if (this.gameObject.name == "CuboRespuesta3")
            {
                Father.transform.position = new Vector3(31.9f, -37.5f, 96.9f);
            }
            else if (this.gameObject.name == "CuboRespuesta4")
            {
                Father.transform.position = new Vector3(79.7f, -37.5f, 96.9f);
            }
            Invoke("UnlockPiece", 0.5f);
        }
    }
    void UnlockPiece()
    {
        Father.GetComponent<Piezas_DragAndDrop>().placed = false;
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

    private void RegistraColisionGeneral(int elementito, string nombrecolision){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3005;
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

}
