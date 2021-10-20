using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMultiplayer : MonoBehaviour
{
    [SerializeField]
    private CreateRoom _createRoom;
    [SerializeField]
    private RoomListingsMenu _roomListingsMenu;

    private RoomCanvases _roomsCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
        _createRoom.FirstInitialize(canvases);
        _roomListingsMenu.FirstInitialize(canvases);
    }
}
