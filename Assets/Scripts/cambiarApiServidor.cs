using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarApiServidor : MonoBehaviour
{
    // Start is called before the first frame update
    public static string URL = "https://7tv5uzrpoj.execute-api.sa-east-1.amazonaws.com/prod/api";
    void Start()
    {
        URL="https://7tv5uzrpoj.execute-api.sa-east-1.amazonaws.com/prod/api";
        // URL="http://localhost:3002/api";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
