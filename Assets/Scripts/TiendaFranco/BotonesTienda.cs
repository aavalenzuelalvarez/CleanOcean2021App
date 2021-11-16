using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BotonesTienda : MonoBehaviour
{
    // Start is called before the first frame update
    public int id_elemento;
    int cantidadElemento; 
    private int elementitotienda;
    private float ejesitox;
    private float ejesitoy;
    private float ejesitoz;
    public int pos_elm = 0;
    [SerializeField] private GameObject[] PrefabZonaPez;
    private int periodito = 202102;
    public UlearnCoins ulearnCoins;
    public GameObject[] CosasqueMostrar;
    public GameObject UlearnetcoinSuficientes;
    public GameObject UlearnetcoinInsuficientes;
    public GameObject play;
    public GameObject JuegoTerminado;
    private static int ContReseteos;
    //-----------------------------------------------------------------------
    // public void crearInvNaves()
    // {   
        
    //     inventario_reim_class INV;
    //     INV = new inventario_reim_class();
    //     INV.sesion_id = AsignaReimAlumno.Session;
    //     INV.cantidad = 0;
    //     INV.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        
    //     for (int x=800131;x<=800142;x++){
    //         Debug.Log("post if x = " + x);
    //         INV.id_elemento = x;
    //         StartCoroutine(Post(INV));
    //     }
    // }
    //-----------------------------------------------------------------------


    // public void SeleccionarNave(int NaveSeleccionada)
    // {
    //     pos_elm=NaveSeleccionada;
    //     InfoNaves.SetActive(true);
    //     TiendaDeNaves.SetActive(false);
    //     VolverASeleccion.SetActive(false);
    //     if (pos_elm >= PrefabZonaPez.Length)
    //     {
    //         pos_elm = 0;
    //     }
    //     if (pos_elm < PrefabZonaPez.Length && pos_elm >= 0)
    //     {
    //         TextoNombreNave.text = NombreNave[pos_elm];
    //         TextoInfoNave.text = InfoNave[pos_elm]; 
    //         ImagenNave.GetComponent<UnityEngine.UI.Image>().sprite = SpriteImagenNave[pos_elm];
    //         TextoPrecioNave.text = PrecioNave[pos_elm].ToString();
    //         id_elemento=pos_elm+800131;
    //         Debug.Log("id_elemento = "+id_elemento);
    //     }
    // }

    // public void boton_Tienda(){

    // SeleccionarQueHacer.SetActive(false);
    // TiendaDeNaves.SetActive(true);
    // VolverAlMenu.SetActive(false);
    // VolverASeleccion.SetActive(true);
    // for (int i = 0; i < PrefabZonaPez.Length; i++)
    // {
    //     TextoPrecioNaveScrollView[i].text = PrecioNave[i].ToString();
    // }
    // }
    // public void boton_volver_seleccion(){

    // SeleccionarQueHacer.SetActive(true);
    // TiendaDeNaves.SetActive(false);
    // IntercambiarNaves.SetActive(false);
    // VolverAlMenu.SetActive(true);
    // VolverASeleccion.SetActive(false);
    // }
    // public void boton_volver_tienda(){

    // TiendaDeNaves.SetActive(true);
    // InfoNaves.SetActive(false);
    // VolverASeleccion.SetActive(true);
    // } 
   
    // public void boton_Intercambiar(){

    // SeleccionarQueHacer.SetActive(false);
    // IntercambiarNaves.SetActive(true);
    // VolverAlMenu.SetActive(false);
    // VolverASeleccion.SetActive(true);
    // }

   
    //Aceptar---------------------------------------------
    // public void AceptarNave()
    // {
    //     inventario_reim_class INV;
    //     INV = new inventario_reim_class();
    //     INV.sesion_id = AsignaReimAlumno.Session;
    //     INV.id_elemento = id_elemento;
    //     INV.cantidad = 1;
    //     INV.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        
    //     AlumnoRespuestaActividad ARA;
    //     ARA = new AlumnoRespuestaActividad();
    //     ARA.id_reim = 1000;
    //     ARA.id_actividad = 40012;
    //     ARA.id_elemento = id_elemento;
    //     ARA.datetime_touch = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    //     ARA.Eje_X = Convert.ToInt32(Input.mousePosition.x);
    //     ARA.Eje_Y = Convert.ToInt32(Input.mousePosition.y);
    //     ARA.Eje_Z = Convert.ToInt32(Input.mousePosition.z);
    //     ARA.correcta = 1;
    //     ARA.id_user = Login.usuarios_id;
    //     ARA.id_per = periodito;
    //     ARA.resultado = "Acaba de comprar un pez ";
    //     ARA.Tipo_Registro = 0;

    //     Debug.Log("Date time creation ="+INV.datetime_creacion);
    //     Debug.Log("cantidad de naves antes de corrutina "+cantidadElemento);
    //     StartCoroutine(GetNaves(Login.usuarios_id, id_elemento,INV,ARA));
    //     Debug.Log("cantidad de naves despues de corrutina "+cantidadElemento);

    // }  

    //Vender---------------------------------------------
    
    // public void VenderNave()
    // {
    //     inventario_reim_class INV;
    //     INV = new inventario_reim_class();
    //     INV.sesion_id = AsignaReimAlumno.Session;
    //     INV.id_elemento = id_elemento;
    //     INV.cantidad = 0;
    //     INV.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        
    //     AlumnoRespuestaActividad ARA;
    //     ARA = new AlumnoRespuestaActividad();
    //     ARA.id_reim = 1000;
    //     ARA.id_actividad = 40012;
    //     ARA.id_elemento = id_elemento;
    //     ARA.datetime_touch = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    //     ARA.Eje_X = Convert.ToInt32(Input.mousePosition.x);
    //     ARA.Eje_Y = Convert.ToInt32(Input.mousePosition.y);
    //     ARA.Eje_Z = Convert.ToInt32(Input.mousePosition.z);
    //     ARA.correcta = 1;
    //     ARA.id_user = Login.usuarios_id;
    //     ARA.id_per = 202101;
    //     ARA.resultado = NombreNave[pos_elm];
    //     ARA.Tipo_Registro = 0;

    //     Debug.Log("Date time creation ="+INV.datetime_creacion);
    //     Debug.Log("cantidad de naves antes de corrutina "+cantidadElemento);
    //     StartCoroutine(GetNavesVender(Login.usuarios_id, id_elemento,INV,ARA));
    //     Debug.Log("cantidad de naves despues de corrutina "+cantidadElemento);

    // }
    //----------------------------------------------------

    public void definirId(){
        pos_elm = Random.Range(0, 20);
        if(pos_elm == 0){
            id_elemento = 3012;
        }else if(pos_elm >= 1 && pos_elm <= 19){
            id_elemento = pos_elm + 3020;
        }

        inventario_reim_class INV;
        INV = new inventario_reim_class();
        INV.sesion_id = AsignaReimAlumno.Session;
        INV.id_elemento = id_elemento;
        INV.cantidad = 1;
        INV.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        
        Respuesta ARA;
        ARA = new Respuesta();
        ARA.id_reim = 500;
        ARA.id_actividad = 3011;
        ARA.id_elemento = id_elemento;
        ARA.datetime_touch = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        ARA.Eje_X = Convert.ToInt32(Input.mousePosition.x);
        ARA.Eje_Y = Convert.ToInt32(Input.mousePosition.y);
        ARA.Eje_Z = Convert.ToInt32(Input.mousePosition.z);
        ARA.correcta = 0;
        ARA.id_user = int.Parse(Conexiones.id_user);
        ARA.id_per = periodito;
        ARA.resultado = "Acaba de comprar un pez ";
        ARA.Tipo_Registro = 0;
        StartCoroutine(GetNaves(int.Parse(Conexiones.id_user), id_elemento, INV, ARA));
    }

    public IEnumerator GetNaves(int id_usuario, int id_elemento,inventario_reim_class INV,Respuesta ARA)
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
            else 
            {
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                if (www.isDone) 
                {
                    if(result != "null")
                    {
                        var StockNotJson = JsonUtility.FromJson<get_cantidad>(result);
                        cantidadElemento= StockNotJson.cantidad;
                        if (cantidadElemento==0){
                            Debug.Log("cantidad de planetas dentro del if "+cantidadElemento);
                            
                            if (int.Parse(ulearnCoins.GetComponent<Text>().text) >= 850){
                                StartCoroutine(Post(INV));
                                ulearnCoins.Restar_UlearnCoins(850);
                                SistemaNaves.contAnimales = SistemaNaves.contAnimales + 1;
                                SetElementoFinal();
                                RegistraPezAdquirido();
                                Debug.Log("Peces que tiene hasta ahora segun barra prog " + (SistemaNaves.contAnimales));
                                play = Instantiate(PrefabZonaPez[pos_elm]) as GameObject;
                                UlearnetcoinSuficientes.SetActive(true);
                            }
                            else{
                                UlearnetcoinInsuficientes.SetActive(true);
                                SetElementoFinal();
                                RegistrarNoPlatita();
                            }
                        }
                        else if((SistemaNaves.contAnimales) == 20){
                            JuegoTerminado.SetActive(true);
                        }
                        else if(cantidadElemento == 1){
                            Debug.Log("ya tiene "+cantidadElemento+"nave");
                            definirId();
                        }
                    }
                }
            }
        }
    } 

    public void cerrarPanelInsuficiente(){
        foreach(GameObject cositas in CosasqueMostrar){
            cositas.SetActive(true);
        }
        UlearnetcoinInsuficientes.SetActive(false);

    }
    public void cerrarPanelSuficiente(){
        foreach(GameObject cositas in CosasqueMostrar){
            cositas.SetActive(true);
        }
        UlearnetcoinSuficientes.SetActive(false);
    }
    public void cerrarPanelJuegoTerminado(){
        foreach(GameObject cositas in CosasqueMostrar){
            cositas.SetActive(true);
        }
        JuegoTerminado.SetActive(false);
    }
    // public IEnumerator GetNavesVender(int id_usuario, int id_elemento,inventario_reim_class INV,AlumnoRespuestaActividad ARA)
    // {
    //     get_cantidad objeto = new get_cantidad();
    //     objeto.usuario_id = id_usuario;
    //     objeto.id_elemento = id_elemento;

    //     string urlAPI = cambiarApiServidor.URL+"/Inventario_reim/get_cantidad";

    //     var jsonData = JsonUtility.ToJson(objeto);
    //     //Debug.Log(jsonData);
    //     using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)) {
    //         www.SetRequestHeader("content-type", "application/json");
    //         www.uploadHandler.contentType = "application/json";
    //         www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
    //         yield return www.SendWebRequest();

    //         if (www.result == UnityWebRequest.Result.ConnectionError) {
    //             Debug.Log(www.error);
    //         }
    //         else 
    //         {
    //             var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
    //             if (www.isDone) 
    //             {
    //                 if(result != "null")
    //                 {
    //                     var StockNotJson = JsonUtility.FromJson<get_cantidad>(result);
    //                     cantidadElemento= StockNotJson.cantidad;
    //                     if (cantidadElemento==1){
    //                         Debug.Log("cantidad de planetas dentro del if vender"+cantidadElemento);
    //                         StartCoroutine(Post(INV));
    //                         insertElemento((int)inventario_reim.actual_ulearnetcoins+PrecioNave[pos_elm],800129);
    //                         //play = Instantiate(PrefabZonaPez[id_elemento-800131]) as GameObject;
    //                         NaveVendida.SetActive(true);

    //                     }
    //                     else{
    //                         Debug.Log("ya tiene "+cantidadElemento+"nave");
    //                         NoTienesEstaNave.SetActive(true);
    //                     }

    //                 }
    //             }
    //         }
    //     }
    // } 
    // public void BotonYaTienesEsteElemento()
    // {
    //     YaTienesEstaNave.SetActive(false);
    // }
    public void BotonUlearnetcoinInsuficientes()
    {
        UlearnetcoinInsuficientes.SetActive(false);
    } 
    // public void BotonNaveVendida()
    // {
    //     NaveVendida.SetActive(false);
    // }
    // public void BotonNoTienesEstaNave()
    // {
    //     NoTienesEstaNave.SetActive(false);
    // } 

    public IEnumerator Post(inventario_reim_class a)  {
        string urlAPI = cambiarApiServidor.URL+"/Inventario_reim/add" ;
        //Debug.Log("urlPI: "+urlAPI);
        Debug.Log("Entro al POST");

        var jsonData = JsonUtility.ToJson(a);
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)) {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError) {
                Debug.Log(www.error);
                Debug.Log("error!");
            }
            else {
                if (www.isDone) {   
                    //Debug.Log("Se actualizo correctamente"+ extend);
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //Debug.Log(result);
                    if (result != null) {
                    }
                }
            }
        }
    }  
    public void BotonResetCompleto(){
        insertElement(3012);

        int var = 3021;
        for (int x = 0; x < 19; x++)
        {
            insertElement(var);
            var = var + 1;
        }
        ContReseteos = ContReseteos + 1;
        Debug.Log("Cantidad de Reseteos = "+ ContReseteos);
    }
    public void insertElement(int id_del_elemento)
    {
        inventario_reim_class ARA;
        ARA = new inventario_reim_class();
        ARA.sesion_id = AsignaReimAlumno.Session;
        ARA.id_elemento = id_del_elemento;
        ARA.cantidad = 0;
        ARA.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        Debug.Log("Date time creation =" + ARA.datetime_creacion);
        StartCoroutine(Post(ARA));
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
    }
    private void RegistraPezAdquirido(){
        Respuesta PezAdquirido;
        PezAdquirido = new Respuesta();
        PezAdquirido.id_per = periodito;
        PezAdquirido.id_user = int.Parse(Conexiones.id_user);
        PezAdquirido.id_reim = 500;
        PezAdquirido.id_actividad = 3011;
        PezAdquirido.id_elemento = elementitotienda;
        DateTime ahora = DateTime.Now;
        PezAdquirido.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        PezAdquirido.Eje_X = ejesitox;
        PezAdquirido.Eje_Y = ejesitoy;
        PezAdquirido.Eje_Z = ejesitoz;
        PezAdquirido.correcta = 1;
        PezAdquirido.resultado = "Pez Adquirido";
        Debug.Log(PezAdquirido.resultado);
        PezAdquirido.Tipo_Registro = 0;
        StartCoroutine(PostAdd(PezAdquirido));
    }

    private void RegistrarNoPlatita(){
        Respuesta PezNoAdquirido;
        PezNoAdquirido = new Respuesta();
        PezNoAdquirido.id_per = periodito;
        PezNoAdquirido.id_user = int.Parse(Conexiones.id_user);
        PezNoAdquirido.id_reim = 500;
        PezNoAdquirido.id_actividad = 3011;
        PezNoAdquirido.id_elemento = elementitotienda;
        DateTime ahora = DateTime.Now;
        PezNoAdquirido.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        PezNoAdquirido.Eje_X = ejesitox;
        PezNoAdquirido.Eje_Y = ejesitoy;
        PezNoAdquirido.Eje_Z = ejesitoz;
        PezNoAdquirido.correcta = 2;
        PezNoAdquirido.resultado = "Pez Adquirido";
        Debug.Log(PezNoAdquirido.resultado);
        PezNoAdquirido.Tipo_Registro = 0;
        StartCoroutine(PostAdd(PezNoAdquirido));
    }
    // public void insertElemento(int numero_cantidad, int id_del_elemento) {
    //     inventario_reim_class INV;
    //     INV = new inventario_reim_class();
    //     INV.sesion_id = AsignaReimAlumno.Session;
    //     INV.id_elemento = id_del_elemento;
    //     INV.cantidad = numero_cantidad;
    //     INV.datetime_creacion = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    //     Debug.Log("Date time creation ="+INV.datetime_creacion);
    //     StartCoroutine(Post(INV));
    // } 
}