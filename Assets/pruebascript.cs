using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebascript : MonoBehaviour
{
    public float[] prueba;
    // Start is called before the first frame update
    void Start()
    {
        prueba = new float[2];
        prueba[0] = 10;
        prueba[1] = 20;
        Debug.Log("Prueba script" + prueba[0]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
