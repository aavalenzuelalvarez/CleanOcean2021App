using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class BotonPausePatrones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hide()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Ocultar");
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
    }
    
    public void Show()
    {
        GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag("Ocultar");
        foreach (GameObject gol in gameObjectArray2)
        {
            gol.SetActive(true);
        }
    }
}
