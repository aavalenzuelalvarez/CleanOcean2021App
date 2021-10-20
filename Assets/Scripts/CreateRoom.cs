using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    private RoomCanvases _roomsCanvases;
    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void OnClick_CreateRoom(){
        if(!PhotonNetwork.IsConnected)
            return;

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Se creo la cosa bien ", this);
        _roomsCanvases.CurrentRoomCanvas.Show();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("No se creo la cosa bien ", this);
    }
}
