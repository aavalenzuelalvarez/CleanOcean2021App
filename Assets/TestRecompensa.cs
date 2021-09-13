using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestRecompensa : MonoBehaviour
{
    public Material Skybox;
    public GameObject Panel_recompensa, Panel_correcto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ClickRecompensa()
    {
        GameObject.Find("Main Camera").GetComponent<Skybox>().enabled = false;
        RenderSettings.skybox = Skybox;
        GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(Panel_recompensa, Panel_correcto);
    }
}
