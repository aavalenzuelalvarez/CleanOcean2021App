using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCanvases : MonoBehaviour
{
    [SerializeField]
    private PanelMultiplayer _panelmultiplayer;
    public PanelMultiplayer PanelMultiplayer {get {return _panelmultiplayer; } }

    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas {get {return _currentRoomCanvas; } }

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        PanelMultiplayer.FirstInitialize(this);
        CurrentRoomCanvas.FirstInitialize(this);
    }
}
