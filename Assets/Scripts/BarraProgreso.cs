using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    Slider Barra;

    public float max;
    public static int act;
    public GameObject Animales;
    public Text ValorString;

    // Start is called before the first frame update

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject); 
        Barra = GetComponent<Slider> ();
    }

    void Update(){
       // act = Animales.Recompensas.porcentaje;
        ActualizarValorBarra (max, act);
    }
    void ActualizarValorBarra(float ValorMax, float ValorAct ){
        float porcentaje;
        porcentaje = ValorAct / ValorMax;
        Barra.value = porcentaje;
        ValorString.text = porcentaje*100 + "%";
    }
}
