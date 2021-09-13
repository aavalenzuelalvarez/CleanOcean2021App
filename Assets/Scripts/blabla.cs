using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blabla : MonoBehaviour
{
    public GameObject btn1;
    public GameObject btn2;
    //public GameObject[] btnini;
    public RectTransform panel;
    void Start()
    {
     //rotatedObject.GetComponent<RotateCamera>().enabled = false;   
     GameObject.Find("Main Camera").GetComponent<RotateCamera>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ini(){
        //btnini = GameObject.FindGameObjectsWithTag("inicio");
        btn1.transform.position=new Vector3(531f, 58f,0);
        btn2.transform.position=new Vector3(47f, 58f,0);
        //rotatedObject.GetComponent<RotateCamera>().enabled = true; 
        GameObject.Find("Main Camera").GetComponent<RotateCamera>().enabled=true;
        
        //for (int i = 0; i < btnini.Length; i++)
        //{
        //    Destroy(btnini[i]);
        //}
    }
}
