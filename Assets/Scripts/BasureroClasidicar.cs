using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasureroClasidicar : MonoBehaviour
{
    public GameObject PanelCorrecciones;
    public GameObject TextoFelicitaciones;
    public GameObject TextoCorrecciones;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Verificar(){
        Debug.Log(this.name + ReciclarDesaparecer.TipoBasura);
        if (this.name == "BasureroPapel" & ReciclarDesaparecer.TipoBasura == "Papel"){
            Debug.Log("BasureroPapel");
            TextoFelicitaciones.GetComponent<Text>().text = "Bien hecho! + 100 Puntos!";
            TextoCorrecciones.GetComponent<Text>().text = "El papel va en el basurero azul!";
            PanelCorrecciones.SetActive(true);
            GameObject.Find("BasureroPapel").SetActive(false);
            GameObject.Find("BasureroPlastico").SetActive(false);
            GameObject.Find("BasureroVidrio").SetActive(false);
        }
        else if (this.name == "BasureroPlastico" & (ReciclarDesaparecer.TipoBasura == "Plastico" || ReciclarDesaparecer.TipoBasura == "Lata")){
            Debug.Log("BasureroPlastico");
            TextoFelicitaciones.GetComponent<Text>().text = "Bien hecho! + 100 Puntos!";
            TextoCorrecciones.GetComponent<Text>().text = "El plastico y lata van en el basurero amarillo!";
            PanelCorrecciones.SetActive(true);
            GameObject.Find("BasureroPapel").SetActive(false);
            GameObject.Find("BasureroPlastico").SetActive(false);
            GameObject.Find("BasureroVidrio").SetActive(false);
        }
        else if (this.name == "BasureroVidrio" & ReciclarDesaparecer.TipoBasura == "Vidrio"){
            Debug.Log("BasureroVidrio");
            TextoFelicitaciones.GetComponent<Text>().text = "Bien hecho! + 100 Puntos!";
            TextoCorrecciones.GetComponent<Text>().text = "El vidrio va en el basurero verde!";
            PanelCorrecciones.SetActive(true);
            GameObject.Find("BasureroPapel").SetActive(false);
            GameObject.Find("BasureroPlastico").SetActive(false);
            GameObject.Find("BasureroVidrio").SetActive(false);
        }
        else{
            if (ReciclarDesaparecer.TipoBasura == "Papel"){
                Debug.Log("La basura de papel va en el basurero azul!");
                TextoFelicitaciones.GetComponent<Text>().text = "Sigue intentando!";
                TextoCorrecciones.GetComponent<Text>().text = "La basura de papel va en el basurero azul!";
                PanelCorrecciones.SetActive(true);
                GameObject.Find("BasureroPapel").SetActive(false);
                GameObject.Find("BasureroPlastico").SetActive(false);
                GameObject.Find("BasureroVidrio").SetActive(false);
            }else if (ReciclarDesaparecer.TipoBasura == "Plastico"){
                Debug.Log("Los envases plasticos van en el basurero amarillo");
                TextoFelicitaciones.GetComponent<Text>().text = "Sigue intentando!";
                TextoCorrecciones.GetComponent<Text>().text = "El plasticos va en el basurero amarillo!";
                PanelCorrecciones.SetActive(true);
                GameObject.Find("BasureroPapel").SetActive(false);
                GameObject.Find("BasureroPlastico").SetActive(false);
                GameObject.Find("BasureroVidrio").SetActive(false);
            }else if (ReciclarDesaparecer.TipoBasura == "Lata"){
                Debug.Log("Las latas van en el mismo basurero que el plastico, el amarillo");
                TextoFelicitaciones.GetComponent<Text>().text = "Sigue intentando!";
                TextoCorrecciones.GetComponent<Text>().text = "Las latas como el plastico, van en el amarillo!";
                PanelCorrecciones.SetActive(true);
                GameObject.Find("BasureroPapel").SetActive(false);
                GameObject.Find("BasureroPlastico").SetActive(false);
                GameObject.Find("BasureroVidrio").SetActive(false);
            }else if (ReciclarDesaparecer.TipoBasura == "Vidrio"){
                Debug.Log("El vidrio va en el basurero verde");
                TextoFelicitaciones.GetComponent<Text>().text = "Sigue intentando!";
                TextoCorrecciones.GetComponent<Text>().text = "El vidrio va en el basurero verde!";
                PanelCorrecciones.SetActive(true);
                GameObject.Find("BasureroPapel").SetActive(false);
                GameObject.Find("BasureroPlastico").SetActive(false);
                GameObject.Find("BasureroVidrio").SetActive(false);
            }else{
                Debug.Log("No entro en niuno");
            } //(ReciclarDesaparecer.TipoBasura == "")
                
        }
    }
}
