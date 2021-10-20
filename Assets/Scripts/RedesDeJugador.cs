using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RedesDeJugador : MonoBehaviour
{
    public MonoBehaviour[] codigosQueIgnorar;
    public GameObject[] BotonBajar;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach (var codigo in codigosQueIgnorar)
            {
                codigo.enabled = false;
            }
            foreach (var boton in BotonBajar)
            {
                boton.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
