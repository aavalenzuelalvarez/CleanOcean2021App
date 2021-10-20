using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OwnershipTransferBasura : MonoBehaviourPun
{
    private void OnCollisionEnter(Collision col){
        if (!photonView.IsMine){
            base.photonView.RequestOwnership();
        }
    }
    
}
