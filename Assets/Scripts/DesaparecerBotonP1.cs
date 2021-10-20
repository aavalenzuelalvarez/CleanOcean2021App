using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class DesaparecerBotonP1 : MonoBehaviour
{
    public MonoBehaviour[] codigosQueIgnorar;
    public GameObject[] BotonBajar;
    public GameObject[] BotonBajarCorrecto;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Update()
    {
        // photonView = GetComponent<PhotonView>();
        foreach (var codigo in codigosQueIgnorar)
            {
                codigo.enabled = true;
            }
        foreach (var boton in BotonBajar)
            {
                if(boton.GetComponent<PhotonView>().IsMine){
                    boton.SetActive(true);
                }else{
                    boton.SetActive(false);
                }
                
            }
        // if(photonView.IsMine){
        //     foreach (var codigo in codigosQueIgnorar)
        //     {
        //         codigo.enabled = true;
        //     }
        //     foreach (var boton in BotonBajar)
        //     {
        //         boton.SetActive(true);
        //     }
        // }
        // else{
        //     foreach (var codigo in codigosQueIgnorar)
        //     {
        //         codigo.enabled = false;
        //     }
        //     foreach (var boton in BotonBajar)
        //     {
        //         boton.SetActive(false);
        //     }
        // }
    }
}
