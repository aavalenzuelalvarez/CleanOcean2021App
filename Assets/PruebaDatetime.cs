using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PruebaDatetime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ahora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
