using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActividadDestreza : MonoBehaviour
{
    public GameObject BasuraPrefab;
    public bool encendida = true;

    void Start()
    {
        InvokeRepeating("encender", 0.0f, Random.Range(3f, 5f));

    }

    // Update is called once per frame
    void Update()
    {
        if (encendida == false)
        {

            BasuraPrefab.transform.gameObject.SetActive(false);
            
        }
        else if (encendida == true)
        {
            BasuraPrefab.transform.gameObject.SetActive(true);
            
        }
    }
    public void apagar()
    {
        encendida = false;
    }
    public void encender()
    {
        encendida = true;
    }
    public void agrega(GameObject bolsa)
    {
        bolsa.SetActive(true);
    }
}
