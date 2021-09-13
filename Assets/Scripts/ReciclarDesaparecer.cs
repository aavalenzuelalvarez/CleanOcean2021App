using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciclarDesaparecer : MonoBehaviour
{
    public bool altura = false;
    public GameObject PanelCalificar;
    public GameObject[] Basura;
    public int i;
    private int x;
    private float positiony;
    public static string TipoBasura = "";
    // private int x = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TipoBasura);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.GetComponent<Transform>().position.y);
        if (this.GetComponent<Transform>().position.y >= 8.47 && altura == false){
            Debug.Log(this.name + " se va a borraaaar");
            MostrarPanelPregunta();
            // this.gameObject.SetActive(true);
            transform.position = new Vector3(2, 5, 60);
            Debug.Log(transform.position.x);
            Debug.Log(transform.position.y);
            TipoBasura = this.tag;
            Debug.Log(TipoBasura);
            // transform.localScale += new Vector3(5f, 5f, 0f);
            // Destroy(this.gameObject);
            altura = true;
            
        }
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
