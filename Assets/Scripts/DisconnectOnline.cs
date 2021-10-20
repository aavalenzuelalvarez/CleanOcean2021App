using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DisconnectOnline : MonoBehaviour
{
    public void SalirSalita(){
        PhotonNetwork.LeaveRoom(true);
    }

    void OnLeftRoom(){
        PhotonNetwork.LoadLevel(2);
    }

    
}
