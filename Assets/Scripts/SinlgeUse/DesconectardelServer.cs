using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class DesconectardelServer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desconectar(){
        PhotonNetwork.LeaveRoom(true);
    }
}
