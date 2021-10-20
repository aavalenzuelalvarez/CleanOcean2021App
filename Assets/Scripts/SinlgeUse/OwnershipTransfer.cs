using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OwnershipTransfer : MonoBehaviourPun
{
    void Start(){
        if (!photonView.IsMine){
            base.photonView.RequestOwnership();
        }
    }
}
