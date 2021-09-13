﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text contador;
    public Text time;
    private float tiempo = 40f;
    // Start is called before the first frame update
    void Start()
    {
        contador.text = "" + tiempo;
        time.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        contador.text = "" + tiempo.ToString("f0");

        if (tiempo <= 0)
        {
            contador.text = "0";
            time.enabled = true;
        }
    }
}
