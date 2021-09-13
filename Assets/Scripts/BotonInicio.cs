using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonInicio : MonoBehaviour
{
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btnaud;
    public RectTransform panel;
    public GameObject Slider;
    void Start()
    {
     //rotatedObject.GetComponent<RotateCamera>().enabled = false;   
     //GameObject.Find("Main Camera").GetComponent<RotateCamera>().enabled=false;
    }
    public void empezamo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ini(){
        //btnini = GameObject.FindGameObjectsWithTag("inicio");
        //btn1.transform.position=new Vector3(531f, 58f,0);
        //btn2.transform.position=new Vector3(47f, 58f,0);
        GameObject.Find("Main Camera").GetComponent<Gyroscope>().enabled = true;
        GameObject.Find("Boton play").GetComponent<Audio>().Reproducir();
        Invoke("Ini2", 1.9f);

        //rotatedObject.GetComponent<RotateCamera>().enabled = true; 
        //GameObject.Find("Main Camera").GetComponent<Camtest>().enabled=true;

        //for (int i = 0; i < btnini.Length; i++)
        //{
        //    Destroy(btnini[i]);
        //}
    }
    //public void Back()
    //{
    //    panel.gameObject.SetActive(true);
    //    btn1.SetActive(false);
    //    btn2.SetActive(false);
    //    Slider.SetActive(false);
    //    //rotatedObject.GetComponent<RotateCamera>().enabled = true; 
    //    //GameObject.Find("Main Camera").GetComponent<Camtest>().enabled = false;
    //}
    public void Ini2()
    {
        controladorpanelprogreso.panel = 0;
    }
}
