using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class ReciclarDesaparecer : MonoBehaviour
{
    public bool altura = false;
    public GameObject PanelCalificar;
    public GameObject[] Basura;
    public int i;
    public int elementobasura;
    public int periodito = 202102;
    private int ActividadSinMul;
    private int x;
    public static string TipoBasura = "";
    private float ejesitox;
    private float ejesitoz;
    private float ejesitoy;
    // private int x = 1;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name == "Actividad ReciclarOnline"){
            ActividadSinMul = 3010;
        }else{
            ActividadSinMul = 3009;
        }
        Debug.Log(TipoBasura);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.GetComponent<Transform>().position.y);
        if (this.GetComponent<Transform>().position.y >= 7.8 && altura == false){
            Debug.Log(this.name + " se va a borraaaar");
            ejesitox = gameObject.transform.position.x;
            ejesitoy = gameObject.transform.position.y;
            ejesitoz = gameObject.transform.position.z;
            RegistraBasuraPescada();
            transform.position = new Vector3(2, 8, 60);
            MostrarPanelPregunta();
            // this.gameObject.SetActive(true);
            Debug.Log(transform.position.x);
            Debug.Log(transform.position.y);
            TipoBasura = this.tag;
            // Debug.Log(TipoBasura);
            // transform.localScale += new Vector3(5f, 5f, 0f);
            // Destroy(this.gameObject);
            altura = true;
            
        }
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

    public void RegistraBasuraPescada(){
        Respuesta BasuraPescada;
        BasuraPescada = new Respuesta();
        BasuraPescada.id_per = periodito;
        BasuraPescada.id_user = int.Parse(Conexiones.id_user);
        BasuraPescada.id_reim = 500;
        BasuraPescada.id_actividad = ActividadSinMul;
        BasuraPescada.id_elemento = elementobasura;
        DateTime ahora = DateTime.Now;
        BasuraPescada.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        BasuraPescada.Eje_X = ejesitox;
        BasuraPescada.Eje_Y = ejesitoy;
        BasuraPescada.Eje_Z = ejesitoz;
        BasuraPescada.correcta = 2;
        BasuraPescada.resultado = "Objeto Colisionado";
        BasuraPescada.Tipo_Registro = 0;
        StartCoroutine(PostAdd(BasuraPescada));
    }

    public void MostrarPanelPregunta(){
        PanelCalificar.SetActive(true);
        Time.timeScale = 0;
        OcultarCosas();
        this.gameObject.SetActive(true);
        // this.GetComponent<Transform>().position.y = 8.47; 
        // this.GetComponent<Transform>().scale.y = 20;
        // this.GetComponent<Transform>().scale.x = 20;

        // if (x = 1){
        //     PanelCalificar.SetActive(true);
        //     x = -1
        // }else{
        //     PanelCalificar.SetActive(false);
        //     x = 1
        // }
    }
    public void OcultarCosas(){
        for (i = 0; i <= Basura.Length - 1; i++)
        {
            if (Basura[i] == null){
                Debug.Log("Este murio");
            }else{
                Basura[i].SetActive(false);
            }
        }
    }

    public void MostrarCosas(){
        for (i = 0; i <= Basura.Length - 1; i++)
        {
            Basura[i].SetActive(true);
        }
    }
    public void OcultarPanelPregunta(){
        PanelCalificar.SetActive(false);
        Time.timeScale = 1;
        MostrarCosas();
        this.gameObject.SetActive(false);
    } 
    public void Destruir(){
        Destroy(this.gameObject);
    }

    // public void VerificarCorrecto(){
    //     if (TipoBasurero == TipoBasura){
    //         Debug.Log("Dar 10 puntos");
    //     }else{
    //         Debug.Log("Ta mal");
    //     }
        // }else if (TipoBasurero == "Papel" and TipoBasura == )
    // }

    // private void DesaparecerBasura(){
    //     if ()
    // }

}
