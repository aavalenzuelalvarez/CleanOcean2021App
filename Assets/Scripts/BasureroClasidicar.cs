using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class BasureroClasidicar : MonoBehaviour
{
    public GameObject PanelCorrecciones;
    public GameObject TextoFelicitaciones;
    public GameObject TextoCorrecciones;
    public UlearnCoins ulearnCoins;
    public int periodito = 202102;
    public int elementito;
    private int ActividadSinMul;
    public static int correctita;
    public static float ejesitox;
    public static float ejesitoy;
    public static float ejesitoz;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Actividad ReciclarOnline"){
            ActividadSinMul = 3010;
        }else{
            ActividadSinMul = 3009;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void SetElementoBasurero(string elementoide){
        elementito = int.Parse(elementoide);
        ejesitox = gameObject.transform.position.x;
        ejesitoy = gameObject.transform.position.y;
        ejesitoz = gameObject.transform.position.z;
    }

    public void RegistraBasuraCorrecta(){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = ActividadSinMul;
        RespuestaBasura.id_elemento = elementito;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 1;
        RespuestaBasura.resultado = "Respuesta Correcta";
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }

    public void RegistraBasuraIncorrecta(){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = ActividadSinMul;
        RespuestaBasura.id_elemento = elementito;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 0;
        RespuestaBasura.resultado = "Respuesta Incorrecta";
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }

    public void Verificar(){
        Debug.Log(this.name + ReciclarDesaparecer.TipoBasura);
        if (this.name == "BasureroPapel" & ReciclarDesaparecer.TipoBasura == "Papel"){
            RegistraBasuraCorrecta();
            Debug.Log("Registrado en BD como 3086");
            TextoFelicitaciones.GetComponent<Text>().text = "Bien hecho! + 100 Puntos!";
            TextoCorrecciones.GetComponent<Text>().text = "El papel va en el basurero azul!";
            PanelCorrecciones.SetActive(true);
            ulearnCoins.Ganar_UlearnCoins(100);
            GameObject.Find("BasureroPapel").SetActive(false);
            GameObject.Find("BasureroPlastico").SetActive(false);
            GameObject.Find("BasureroVidrio").SetActive(false);
        }
        else if (this.name == "BasureroPlastico" & (ReciclarDesaparecer.TipoBasura == "Plastico" || ReciclarDesaparecer.TipoBasura == "Lata")){
            RegistraBasuraCorrecta();
            Debug.Log("Registrado en BD como 3087");
            TextoFelicitaciones.GetComponent<Text>().text = "Bien hecho! + 100 Puntos!";
            TextoCorrecciones.GetComponent<Text>().text = "El plastico y lata van en el basurero amarillo!";
            PanelCorrecciones.SetActive(true);
            ulearnCoins.Ganar_UlearnCoins(100);
            GameObject.Find("BasureroPapel").SetActive(false);
            GameObject.Find("BasureroPlastico").SetActive(false);
            GameObject.Find("BasureroVidrio").SetActive(false);
        }
        else if (this.name == "BasureroVidrio" & ReciclarDesaparecer.TipoBasura == "Vidrio"){
            RegistraBasuraCorrecta();
            Debug.Log("Registrado en BD como 3088");
            TextoFelicitaciones.GetComponent<Text>().text = "Bien hecho! + 100 Puntos!";
            TextoCorrecciones.GetComponent<Text>().text = "El vidrio va en el basurero verde!";
            PanelCorrecciones.SetActive(true);
            ulearnCoins.Ganar_UlearnCoins(100);
            GameObject.Find("BasureroPapel").SetActive(false);
            GameObject.Find("BasureroPlastico").SetActive(false);
            GameObject.Find("BasureroVidrio").SetActive(false);
        }
        else{
            if (ReciclarDesaparecer.TipoBasura == "Papel"){
                RegistraBasuraIncorrecta();
                Debug.Log("Registrado en BD como 3086");
                TextoFelicitaciones.GetComponent<Text>().text = "Sigue intentando!";
                TextoCorrecciones.GetComponent<Text>().text = "La basura de papel va en el basurero azul!";
                PanelCorrecciones.SetActive(true);
                GameObject.Find("BasureroPapel").SetActive(false);
                GameObject.Find("BasureroPlastico").SetActive(false);
                GameObject.Find("BasureroVidrio").SetActive(false);
            }else if (ReciclarDesaparecer.TipoBasura == "Plastico"){
                RegistraBasuraIncorrecta();
                Debug.Log("Registrado en BD como 3087");
                TextoFelicitaciones.GetComponent<Text>().text = "Sigue intentando!";
                TextoCorrecciones.GetComponent<Text>().text = "El plasticos va en el basurero amarillo!";
                PanelCorrecciones.SetActive(true);
                GameObject.Find("BasureroPapel").SetActive(false);
                GameObject.Find("BasureroPlastico").SetActive(false);
                GameObject.Find("BasureroVidrio").SetActive(false);
            }else if (ReciclarDesaparecer.TipoBasura == "Lata"){
                RegistraBasuraIncorrecta();
                Debug.Log("Registrado en BD como 3087");
                TextoFelicitaciones.GetComponent<Text>().text = "Sigue intentando!";
                TextoCorrecciones.GetComponent<Text>().text = "Las latas como el plastico, van en el amarillo!";
                PanelCorrecciones.SetActive(true);
                GameObject.Find("BasureroPapel").SetActive(false);
                GameObject.Find("BasureroPlastico").SetActive(false);
                GameObject.Find("BasureroVidrio").SetActive(false);
            }else if (ReciclarDesaparecer.TipoBasura == "Vidrio"){
                RegistraBasuraIncorrecta();
                Debug.Log("Registrado en BD como 3088");
                TextoFelicitaciones.GetComponent<Text>().text = "Sigue intentando!";
                TextoCorrecciones.GetComponent<Text>().text = "El vidrio va en el basurero verde!";
                PanelCorrecciones.SetActive(true);
                GameObject.Find("BasureroPapel").SetActive(false);
                GameObject.Find("BasureroPlastico").SetActive(false);
                GameObject.Find("BasureroVidrio").SetActive(false);
            }else{
                Debug.Log("No entro en niuno");
            } //(ReciclarDesaparecer.TipoBasura == "")
                
        }
    }
}
