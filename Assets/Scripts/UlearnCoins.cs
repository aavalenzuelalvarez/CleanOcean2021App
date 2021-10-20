using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class UlearnCoins : MonoBehaviour
{
    int ulearnCoins_obtenidos;

    //public GameObject CargarNivel;
    //public CargadorNivel ara = new CargadorNivel();
    // public CargadorNivel cargarNivel = new CargadorNivel();

    public GameObject obj;
    
    void awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //insertElement(0,600235);
        get_UlearnCoins();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ObtenerAnimal()
    {
        if(ulearnCoins_obtenidos - 10 < 0)
        {
            obj.SetActive(true);
            Debug.Log("No tienes Suficientes puntos");
        }else
        {
            ulearnCoins_obtenidos = ulearnCoins_obtenidos - 10;
            insertElement(ulearnCoins_obtenidos,600235);
            // cargarNivel.CargarNivel(3);
            
        }
    }

    public void get_UlearnCoins()
    {
        StartCoroutine(Get(User.usuarios_id, 600235,"get_cantidad"));
        
    }

    public void Ganar_UlearnCoins(int coins_ganadas)
    {
        ulearnCoins_obtenidos = ulearnCoins_obtenidos + coins_ganadas;
        insertElement(ulearnCoins_obtenidos,600235);
        gameObject.GetComponent<Text>().text = ulearnCoins_obtenidos + "" ;
        Debug.Log(ulearnCoins_obtenidos + " UlearnCoins");
    }
    public void Restar_UlearnCoins(int coins_ganadas)
    {
        ulearnCoins_obtenidos = ulearnCoins_obtenidos - coins_ganadas;
        insertElement(ulearnCoins_obtenidos,600235);
        gameObject.GetComponent<Text>().text = ulearnCoins_obtenidos + "";
        Debug.Log(ulearnCoins_obtenidos + " UlearnCoins");
    }
    public IEnumerator Get(int id_usuario, int id_elemento, string extend)
    {
        get_cantidad objeto = new get_cantidad();
        objeto.usuario_id = id_usuario;
        objeto.id_elemento = id_elemento;

        string urlAPI = cambiarApiServidor.URL + "/inventario_reim/" + extend;
        //URL="https://7tv5uzrpoj.execute-api.sa-east-1.amazonaws.com/prod/api";\
        //cambiarApiServidor.URL + "http://localhost:3002/api/inventario_reim/"

        var jsonData = JsonUtility.ToJson(objeto);
        //Debug.Log(jsonData);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                //Debug.Log(result);
                if (www.isDone)
                {
                    if (result != "null")// con esto evitamos que dropee errores si no encuentra un resultado al hacer la consulta
                    {
                        var StockNotJson = JsonUtility.FromJson<get_cantidad>(result);
                        ulearnCoins_obtenidos = StockNotJson.cantidad;
                        Debug.Log(ulearnCoins_obtenidos + "UlearnCoins");
                        gameObject.GetComponent<Text>().text = ulearnCoins_obtenidos + "";

                    }

                }

            }

        }

    }

    public void insertElement(int numero_cantidad, int id_del_elemento)
    {

        inventario_reim_class ARA;
        ARA = new inventario_reim_class();
        ARA.sesion_id = AsignaReimAlumno.Session;
        ARA.id_elemento = id_del_elemento;
        ARA.cantidad = numero_cantidad;
        ARA.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //Debug.Log("Date time creation =" + ARA.datetime_creacion);
        StartCoroutine(Postt(ARA, "add"));
    }
    public IEnumerator Postt(inventario_reim_class a, string extend)
    {
        //yield return new WaitForSeconds(2);
        string urlAPI = "http://localhost:3002/api/Inventario_reim/" + extend;
        //Debug.Log("urlPI: "+urlAPI);

        var jsonData = JsonUtility.ToJson(a);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
                Debug.Log("error!");
            }
            else
            {
                if (www.isDone)
                {
                    //Debug.Log("Se actualizo correctamente"+ extend);
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //Debug.Log(result);
                    if (result != null)
                    {
                        if (extend == "add")
                        {
                            //Debug.Log("Session: "+Session);
                            //Session = result;
                        }
                        //var asignaRA = JsonUtility.FromJson<AsignaInicio>(result);
                        
                    }
                }
            }
        }
    }
}
