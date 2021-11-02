using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelesMultiPMenu : MonoBehaviour
{
    public GameObject PanelDecision, PanelCrearSala;
    public GameObject[] Ocultar;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject boton in Ocultar){
            boton.SetActive(true);
        }
        PanelDecision.SetActive(false);
        PanelCrearSala.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AbrirPanelDecision(){
        foreach (GameObject boton in Ocultar){
            boton.SetActive(false);
        }
        PanelDecision.SetActive(true);
    }
    public void CerrarPanelDecision(){
        foreach (GameObject boton in Ocultar){
            boton.SetActive(true);
        }
        PanelDecision.SetActive(false);
    }
    public void AbrirPanelCrearSala(){
        PanelCrearSala.SetActive(true);
        PanelDecision.SetActive(false);
    }
    public void CerrarPanelCrearSala(){
        PanelCrearSala.SetActive(false);
        PanelDecision.SetActive(true);
    }
}
