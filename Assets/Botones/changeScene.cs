﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class changeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   

    }
    // Update is called once per frame
    void Update()
    {        

    }
    public void CargarNivel(string pSceneName){
        SceneManager.LoadScene (pSceneName);
    }

}