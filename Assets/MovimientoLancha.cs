using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class MovimientoLancha : MonoBehaviour
{
    public float g = 9.8f,positiony;
    public float speed = 10;
    public int colisiones=0,aux=0,x;
    public Material Skybox;
    public GameObject Panel_correcto, Panel_incorrecto;
    private float ejesitox;
    private float ejesitoy;
    private float ejesitoz;
    public int periodito = 202102;
    public UlearnCoins ulearnCoins;
    private string colisionsita;
    private Rigidbody rb;
    // private bool moveleft;
    // private bool moverighto;
    // public float speedobutton = 5;
    private float horizontalMove;

    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // moveleft = false;
        // moverighto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (colisiones >= 20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            speed = 0;
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name);
            ulearnCoins.Ganar_UlearnCoins(250);
            Panel_incorrecto.SetActive(true);
            colisiones = 0;
        }
        if (colisiones <= 20 && GetComponent<Transform>().position.z >= GameObject.Find("Isla actLancha").GetComponent<Transform>().position.z - 58 && aux==0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            speed = 0;
            ejesitox = GameObject.Find("Isla actLancha").GetComponent<Transform>().position.x;
            ejesitoy = GameObject.Find("Isla actLancha").GetComponent<Transform>().position.y;
            ejesitox = GameObject.Find("Isla actLancha").GetComponent<Transform>().position.z;
            RegistraBasuraCorrecta(3046, "Isla actLancha");
            ulearnCoins.Ganar_UlearnCoins(500);
            GameObject.Find("Main Camera").GetComponent<Skybox>().enabled = false;
            RenderSettings.skybox = Skybox;
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name);
            Panel_correcto.SetActive(true);
            // conexiones.UpdateTimeActividad(1);
            colisiones = 0;
            aux += 1;
        }
    }
    void FixedUpdate()
    {
        // rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (speed < 20 && speed > 0)
        {
            speed += 0.005f;
        }
        // normalize axis
        var gravity = new Vector2(Input.acceleration.x, 0) * g;
        GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
        GetComponent<Transform>().rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0.69f, GetComponent<Transform>().position.z);

    }
    private void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.name == "BasuraPrefab") || (col.gameObject.name == "RuedaPrefab") || (col.gameObject.name == "BarrilPrefab"))
        {
            // GameObject.Find("Conexiones").GetComponent<Conexiones>().Colision(SceneManager.GetActiveScene().name, col.gameObject.name);
            x = Random.Range(-285, -163);
            if (col.gameObject.name == "BasuraPrefab")
            {
                SetElementoFinal(col.gameObject);
                if(colisiones >= 19){
                    RegistraBasuraIncorrecta(3041);
                    col.gameObject.SetActive(false);
                }else{
                    RegistraColisionGeneral(3041, "BasuraPrefab");
                    positiony = -0.63f;
                }
                // colisionsita = col.gameObject.name;
                
            }
            else if (col.gameObject.name == "RuedaPrefab")
            {
                // colisionsita = col.gameObject.name;
                SetElementoFinal(col.gameObject);
                if(colisiones >= 19){
                    RegistraBasuraIncorrecta(3068);
                    col.gameObject.SetActive(false);
                }else{
                    RegistraColisionGeneral(3068, "RuedaPrefab");
                    positiony = -0.3f;
                }
                
            }
            else if (col.gameObject.name == "BarrilPrefab")
            {
                // colisionsita = col.gameObject.name;
                SetElementoFinal(col.gameObject);
                if(colisiones >= 19){
                    RegistraBasuraIncorrecta(3019);
                    col.gameObject.SetActive(false);
                }else{
                    RegistraColisionGeneral(3019, "BarrilPrefab");
                    positiony = -0.4f;
                }
            }
            if (col.transform.position.z + 200 < GameObject.Find("Isla actLancha").GetComponent<Transform>().position.z - 58)
            {
                col.transform.position = new Vector3(x, positiony, GetComponent<Transform>().position.z + 200);
            }
            colisiones++;
            print(colisiones);
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

    private void SetElementoFinal(GameObject colision){
        ejesitox = colision.transform.position.x;
        ejesitoy = colision.transform.position.y;
        ejesitoz = colision.transform.position.z;
        Debug.Log(ejesitox + " " + ejesitoy + " " + ejesitoz);
    }
    private void RegistraBasuraCorrecta(int elementito, string nombrecolision){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3001;
        RespuestaBasura.id_elemento = elementito;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 1;
        RespuestaBasura.resultado = "Respuesta Correcta en : " + nombrecolision;
        Debug.Log(RespuestaBasura.resultado);
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }
    private void RegistraBasuraIncorrecta(int elementito){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3001;
        RespuestaBasura.id_elemento = elementito;
        DateTime ahora = DateTime.Now;
        RespuestaBasura.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        RespuestaBasura.Eje_X = ejesitox;
        RespuestaBasura.Eje_Y = ejesitoy;
        RespuestaBasura.Eje_Z = ejesitoz;
        RespuestaBasura.correcta = 0;
        RespuestaBasura.resultado = "20 Choques";
        RespuestaBasura.Tipo_Registro = 0;
        StartCoroutine(PostAdd(RespuestaBasura));
    }
    private void RegistraColisionGeneral(int elementito, string nombrecolision){
        Respuesta RespuestaBasura;
        RespuestaBasura = new Respuesta();
        RespuestaBasura.id_per = periodito;
        RespuestaBasura.id_user = int.Parse(Conexiones.id_user);
        RespuestaBasura.id_reim = 500;
        RespuestaBasura.id_actividad = 3001;
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
    // public void levantarizquierdant(){
    //      moveleft = false;
    // }
    // public void movimientoizquierda(){
    //     moveleft = true;
        
    // }
    // public void movimientoderecha(){
    //     moverighto = true;
       
    // }
    // public void levantarDerecha(){
    //     moverighto = false;
    // }
    // private void MovementPlayer(){
    //     if(moveleft){
    //         horizontalMove = -speedobutton;
    //     }
    //     else if(moverighto){
    //         horizontalMove = speedobutton;
    //     }
    //     else{
    //         horizontalMove = 0;
    //     }
    // }
}
