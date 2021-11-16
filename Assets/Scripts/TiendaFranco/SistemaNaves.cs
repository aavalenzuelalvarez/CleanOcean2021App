using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SistemaNaves : MonoBehaviour
{   
    public int id_elemento;

    //elemento-----------------------------------------
    [SerializeField] private GameObject[] elemento;
    public int pos_elm = 0;
    public GameObject Objeto;
    public static int contAnimales = 0;
    private int x;

    public void InstanciarNaves(int id_elemento)
    {
        if(id_elemento == 3012){
            Objeto = Instantiate(elemento[0]) as GameObject; //Instanciar este objeto de la lista, segun el elemento
        }else if(id_elemento >= 3021 && id_elemento <= 3039){
            Objeto = Instantiate(elemento[id_elemento-3020]) as GameObject;
        }
        
    }
    public void cargarNaves(){
        x = 3012;
        StartCoroutine(GetInventario(int.Parse(Conexiones.id_user), x));
        for (int x=3021;x<=3039;x++){
            Debug.Log("GetInventarioNaves if x = " + x);
            StartCoroutine(GetInventario(int.Parse(Conexiones.id_user), x));
        }
    }
    public IEnumerator GetInventario(int id_usuario, int id_elemento)
    {
        get_cantidad objeto = new get_cantidad();
        objeto.usuario_id = id_usuario;
        objeto.id_elemento = id_elemento;
        string urlAPI = cambiarApiServidor.URL+"/Inventario_reim/get_cantidad";
        var jsonData = JsonUtility.ToJson(objeto);
        //Debug.Log(jsonData);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)) {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log(www.error);
            }
            else{
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                if (www.isDone){
                    if(result != "null"){
                        var StockNotJson = JsonUtility.FromJson<get_cantidad>(result);
                        if (StockNotJson.cantidad == 1){
                            BarraProgreso.act += 1;
                            contAnimales = contAnimales + 1;
                            Debug.Log("Esto es del get inventario, ojo " + BarraProgreso.act);
                            InstanciarNaves(id_elemento);
                        }
                    }
                }
            }
        }
    }
}
