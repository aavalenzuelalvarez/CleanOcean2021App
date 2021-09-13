using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCorreccionCerrar : MonoBehaviour
{
    public GameObject[] Basura;
    public int i;
    public static int contadordebasura = 0;
    // Start is called before the first frame update
    void Start()
    {
        contadordebasura = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Clickeaste");
            Destroy(GameObject.FindWithTag("Plastico"));
            Destroy(GameObject.FindWithTag("Lata"));
            Destroy(GameObject.FindWithTag("Vidrio"));
            Destroy(GameObject.FindWithTag("Papel"));
            GameObject.Find("Panel Correccion").SetActive(false);
            GameObject.Find("Panel Calificar").SetActive(false);
            MostrarCosas();
            Debug.Log("Se muestra todo de todo");
            // GameObject.Find("BasureroPapel").SetActive(true);
            // GameObject.Find("BasureroPlastico").SetActive(true);
            // GameObject.Find("BasureroVidrio").SetActive(true);
            Time.timeScale = 1;
            contadordebasura = contadordebasura + 1;
            Debug.Log(contadordebasura + " Basura recogida");
        }
    }
    public void MostrarCosas(){
        foreach(GameObject go in Basura){
            try{
                go.SetActive(true);
            }catch{
                Debug.Log("Acaba de morir");
            }
            
            
            // if(go != null){
            //     continue;
            //     Debug.Log("Murio");
            // }else{
            //     go.SetActive(true);
            // }

            
        }
        // for (i = 0; i <= Basura.Length - 1; i++)
        // {
        //     Debug.Log(Basura[i]);
        //     if (Basura[i] == null){
        //         Debug.Log("Este murio");
        //     }else{
        //         Basura[i].SetActive(true);
        //     }
            
        // }
    }
}
