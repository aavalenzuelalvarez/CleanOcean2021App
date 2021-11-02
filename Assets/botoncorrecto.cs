using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class botoncorrecto : MonoBehaviour
{
    public Button btn;
    public GameObject correcto, incorrecto,pregunta,respuestas;
    public int aux2;
    private int periodito;
    private float ejesitox, ejesitoy, ejesitoz;
    public UlearnCoins ulearnCoins;
    // Start is called before the first frame update
    void Start()
    {
        aux2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameObject.Find("Main Camera").GetComponent<deployFish>().count== 3)
        //{
        //    isCorrect();
        //}
    }
    public void isCorrect()
    {
        //Debug.Log(GameObject.Find("Main Camera").GetComponent<deployFish>().respuestacorrecta.ToString());
        pregunta.gameObject.SetActive(false);
        var aux = GameObject.Find("Moorish_idol_prefab(Clone)");
        if (aux == null)
        {
            aux = GameObject.Find("Blue_tang_prefab(Clone)");
            if (aux == null)
            {
                aux = GameObject.Find("Salmon_prefab(Clone)");
                if (aux == null)
                {
                    aux = GameObject.Find("Clownfish_prefab(Clone)");

                    if (aux == null)
                    {
                        aux = GameObject.Find("Green_turtle_prefab(Clone)");
                    }
                }
            }
        }
        aux.SetActive(false);


        if (btn.GetComponentInChildren<Text>().text == (GameObject.Find("Main Camera").GetComponent<deployFish>().respuestacorrecta).ToString() && aux2 == 0)
        {
            SetElementoFinal();
            RegistrarCorrecta();
            ulearnCoins.Ganar_UlearnCoins(500);
            correcto.gameObject.SetActive(true);
            btn.GetComponent<Image>().color = Color.green;
            respuestas.gameObject.SetActive(false);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name, gameObject.name);
            // Invoke("MostrarRecompensa", 3f);
            aux2 += 1;
            
            
        }
        else if (btn.GetComponentInChildren<Text>().text != (GameObject.Find("Main Camera").GetComponent<deployFish>().respuestacorrecta).ToString() && aux2 == 0)
        {
            SetElementoFinal();
            RegistrarIncorrecta();
            ulearnCoins.Ganar_UlearnCoins(250);
            incorrecto.gameObject.SetActive(true);
            respuestas.gameObject.SetActive(false);
            // GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(incorrecto);
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name, gameObject.name);
            //Invoke("ReiniciarAct", 3f);
            aux2 += 1;
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
        RespuestaBasura.id_actividad = 3002;
        RespuestaBasura.id_elemento = 3011;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 1;
        RespuestaBasura.resultado = "Respuesta Correcta";
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
        RespuestaBasura.id_actividad = 3002;
        RespuestaBasura.id_elemento = 3011;
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
    // private void MostrarRecompensa()
    // {
    //     correcto.gameObject.SetActive(false);
    //     GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(recompensa,correcto);
    // }
    // private void ReiniciarAct()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
}
