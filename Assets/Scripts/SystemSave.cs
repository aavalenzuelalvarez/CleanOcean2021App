using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Collections;



[Serializable]
public class Reim{
    public int id;
    public string nombre;

    public Reim(int id, string nombre){
        this.id = id;
        this.nombre = nombre;
    }
}
[Serializable]
public class Actividad{
    public int id;
    public string nombre;
    public int id_reim;

    public Actividad(int id, string nombre, int id_reim){
        this.id = id;
        this.nombre = nombre;
        this.id_reim = id_reim;
    }
}

[Serializable]
public class Tiempoxactividad{
    public int id_tiempoactividad;
    public string inicio;
    public string final;
    public int causa;
    public int usuario_id;
    public int reim_id;
    public int actividad_id;
}

[Serializable]
public class dibujo_reim{
    public int id_imagenes_reim;
    public string sesion_id;
    public int usuario_id;
    public int reim_id;
    public int actividad_id;
    public byte[] imagen;
}

[Serializable]
public class Asigna_reim_alumno{
    public string sesion_id;
    public int usuario_id;
    public int periodo_id;
    public int reim_id;
    public string datetime_inicio;
    public string datetime_termino;

    public Asigna_reim_alumno(string sesion_id, int usuario_id, int periodo_id, int reim_id, string datetime_inicio, string datetime_termino){
        this.sesion_id = sesion_id;
        this.usuario_id = usuario_id;
        this.periodo_id = periodo_id;
        this.reim_id = reim_id;
        this.datetime_inicio = datetime_inicio;
        this.datetime_termino = datetime_termino;
    }
}
public static class SystemSave{
    //Datos del Reim
    public static string wea = "a";
    public static Asigna_reim_alumno asigna_reim_alumno;
    public static Reim reim = new Reim(500, "Clean Ocean 2021");  //Guardamos los datos del reim para futuras consultas
    public static Actividad actividad1 = new Actividad(3001, "Actividad Lancha", 500);
    public static Actividad actividad2 = new Actividad(3002, "Actividad Suma", 500);
    public static Actividad actividad3 = new Actividad(3003, "Actividad Laberinto", 500);
    public static Actividad actividad4 = new Actividad(3004, "Actividad Tesoro", 500);
    public static Actividad actividad5 = new Actividad(3005, "Actividad Arrastrar y Soltar", 500);
    public static Actividad actividad6 = new Actividad(3006, "Actividad Destreza", 500);
    public static Actividad actividad7 = new Actividad(3007, "Actividad Patrones", 500);
    public static Actividad actividad8 = new Actividad(3008, "Actividad Identificar", 500);
    public static Actividad actividad9 = new Actividad(3009, "Actividad Reciclar", 500);
    //Datos de la sesion
    public static Usuario usuario;  //Guardamos los datos del usuario para futuras consultas

    // public static void SavePlayer (CtrlRecursos recursos){
    //     BinaryFormatter formatter = new BinaryFormatter();
    //     string path = Application.persistentDataPath + "/player.sav";
    //     FileStream stream = new FileStream(path, FileMode.Create);

    //     PlayerData data = new PlayerData(recursos);

    //     formatter.Serialize(stream, data);
    //     stream.Close();
    // }

    // public static PlayerData LoadPlayer (){
    //     string path = Application.persistentDataPath + "/player.sav";
    //     if (File.Exists(path)){
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         FileStream stream = new FileStream(path, FileMode.Open);

    //         PlayerData data = formatter.Deserialize(stream) as PlayerData;
    //         stream.Close();

    //         return data;
    //     } else{
    //         Debug.LogError("Archivo de guardado no encontrado en " + path);
    //         return null;
    //     }
    // }

    public static void SaveTiempoActividad(Tiempoxactividad data, MonoBehaviour instance){
        instance.StartCoroutine(addtiempoxactividad(data));
    }

    public static IEnumerator addtiempoxactividad(Tiempoxactividad data){
        string urlAPI = "http://localhost:3002/api/tiempoxactividad/add";
        var jsonData = JsonUtility.ToJson(data);
        Debug.Log("No entra a absolutamente nada jejejejeje");
        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)){
            Debug.Log("Usa el Using1 jejejejejeje");
            www.SetRequestHeader("content-type", "application/Json");
            Debug.Log("Usa el Using2 jejejejejeje");
            www.uploadHandler.contentType = "application/Json";
            Debug.Log("Usa el Using3 jejejejejeje");
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            Debug.Log("Usa el Using4 jejejejejeje");
            yield return new WaitForSeconds(5);
            Debug.Log("Usa el Using45 jejejejejeje");
            yield return www.SendWebRequest();
            Debug.Log("Usa el Using5 jejejejejeje");
            if(www.isNetworkError){
                Debug.Log("Usa el Using6 jejejejejeje");
                Debug.LogError(www.error);
            }else{
                Debug.Log("No entro");
                if(www.isDone){
                    string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(result);
                    if(result != null){
                        //var id = JsonUtility.FromJson<String>(result);
                        Debug.Log(result);
                        data.id_tiempoactividad = int.Parse(result);
                        Debug.Log(data.id_tiempoactividad);
                        Debug.Log("agregado tiempoxactividad");
                    }
                }
            }
        }        
    }

    public static void UpdateTiempoActividad(Tiempoxactividad data, MonoBehaviour instance){
        instance.StartCoroutine(updatetiempoxactividad(data));
    }

    public static IEnumerator updatetiempoxactividad(Tiempoxactividad data){
        string urlAPI = "http://localhost:3002/api/tiempoxactividad/update/" + data.id_tiempoactividad.ToString();
        var jsonData = JsonUtility.ToJson(data);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)){
            www.SetRequestHeader("content-type", "application/Json");
            www.uploadHandler.contentType = "application/Json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();
            if(www.isNetworkError){
                Debug.LogError(www.error);
            }else{
                if(www.isDone){
                    string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if(result != null){
                        //var id = JsonUtility.FromJson<String>(result);
                        //Debug.Log(result);
                        //data.id = Convert.ToInt32(result);
                        Debug.Log(result);
                        Debug.Log("Actualizando tiempoxactividad");
                    }
                }
            }

        }

    }

    public static void Put_asigna_reim_alumno(Asigna_reim_alumno data, MonoBehaviour instance){
        instance.StartCoroutine(put_asigna_reim_alumno(data));
    }

    public static IEnumerator put_asigna_reim_alumno(Asigna_reim_alumno data){
        string urlAPI = "http://localhost:3002/api/asigna_reim_alumno/add";
        var jsonData = JsonUtility.ToJson(data);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)){
            www.SetRequestHeader("content-type", "application/Json");
            www.uploadHandler.contentType = "application/Json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();
            if(www.isNetworkError){
                Debug.LogError(www.error);
            }else{
                if(www.isDone){
                    string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if(result != null){
                        //Debug.Log("Sesion "+data.sesion_id+" registrada");                        
                    }
                    
                }
            }

        }

    }

    // public static void Adddibujoreim(dibujo_reim data, MonoBehaviour instance){
    //     instance.StartCoroutine(adddibujoreim(data));
    // }

    // public static IEnumerator adddibujoreim(dibujo_reim data){
    //     string urlAPI = "http://localhost:3002/api/dibujo_reim/add";
    //     var jsonData = JsonUtility.ToJson(data);

    //     using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData)){
    //         www.SetRequestHeader("content-type", "application/Json");
    //         www.uploadHandler.contentType = "application/Json";
    //         www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
    //         yield return www.SendWebRequest();
    //         if(www.isNetworkError){
    //             Debug.LogError(www.error);
    //         }else{
    //             if(www.isDone){
    //                 string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
    //                 if(result != null){
    //                     data.id_imagenes_reim = Convert.ToInt32(result);;
    //                     Debug.Log(data.id_imagenes_reim);
    //                     Debug.Log("agregado dibujo_reim");
    //                 }
    //             }
    //         }

    //     }

    // }
}

// public struct ListContainer
// {
// 	public List<EdificioData> dataList;

//     /// <summary>
// 	/// Constructor
// 	/// </summary>
// 	/// <param name="_dataList">Data list value</param>
// 	public ListContainer(List<EdificioData> _dataList)
// 	{
// 		dataList = _dataList;
// 	}
// }
