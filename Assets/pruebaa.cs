using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaa : MonoBehaviour
{
    public GameObject Coral5Prefab;
    public bool encendida = false;
    void Start()
    {
        if (this.gameObject.name == "node_id56")
        {
            InvokeRepeating("encender", 0.0f, Random.Range(3f, 5f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (encendida == false)
        {
            Coral5Prefab.GetComponent<Renderer>().material.color = Color.black;
        }
        else if (encendida == true)
        {
            Coral5Prefab.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
    public void negro()
    {
        encendida = false;
    }
    public void encender()
    {
        encendida = true;
    }
}
