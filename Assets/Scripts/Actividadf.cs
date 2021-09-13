using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividadf : MonoBehaviour
{
    TouchPhase touchPhase = TouchPhase.Ended;
    public GameObject BasuraPrefab;
    public GameObject BasuraPrefab1;
    public GameObject BasuraPrefab2;
    public GameObject BasuraPrefab3;
    public GameObject BasuraPrefab4;
    public GameObject BasuraPrefab5;
    public GameObject BasuraPrefab6;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {

                    GameObject touchedObject = hit.transform.gameObject;

                    Debug.Log("Touched " + touchedObject.transform.name);
                    if(touchedObject.transform.name == "BasuraPrefab")
                    {
                        BasuraPrefab.SetActive(false);
                    }
                    else if(touchedObject.transform.name == "BasuraPrefab1")
                    {
                        BasuraPrefab1.SetActive(false);
                    }
                    else if (touchedObject.transform.name == "BasuraPrefab2")
                    {
                        BasuraPrefab2.SetActive(false);
                    }
                    else if (touchedObject.transform.name == "BasuraPrefab3")
                    {
                        BasuraPrefab3.SetActive(false);
                    }
                    else if (touchedObject.transform.name == "BasuraPrefab4")
                    {
                        BasuraPrefab4.SetActive(false);
                    }
                    else if (touchedObject.transform.name == "BasuraPrefab5")
                    {
                        BasuraPrefab5.SetActive(false);
                    }
                    else if (touchedObject.transform.name == "BasuraPrefab6")
                    {
                        BasuraPrefab6.SetActive(false);
                    }

                }
            }
        }
    }

}
