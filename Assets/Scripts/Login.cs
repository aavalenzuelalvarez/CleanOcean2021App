using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
[Serializable]
public class Usuario
{
    public string id;
    public string loginame;
    public string password;
    public string nombre;
}

public class Login : MonoBehaviour
{
    
    public InputField userInput;
    public InputField passwordInput;
    public IEnumerator Post(Usuario usuario)
    {
        string urlAPI = "http://localhost:3002/api/login";
        var jsonData = JsonUtility.ToJson(usuario);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI,jsonData))
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
                if(www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if(result!=null)
                    {
                        var usuarios = JsonUtility.FromJson<Usuario>(result);
                        string[] a = result.ToString().Split(',');
                        string id_user_aux = a[0];
                        string[] b = id_user_aux.Split(':');
                        string id_user = b[1];
                        Conexiones.id_user = id_user;
                        Debug.Log(Conexiones.id_user);
                        SceneManager.LoadScene("Progreso");
                    }
                }
            }
        }
    }
    public void Logearse()
    {
        Usuario usuario;
        usuario = new Usuario();
        usuario.loginame = userInput.GetComponent<InputField>().text;
        usuario.password = passwordInput.GetComponent<InputField>().text;
        StartCoroutine(Post(usuario));
    }
}