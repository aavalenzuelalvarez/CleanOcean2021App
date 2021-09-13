using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ColliderDragnDrop : MonoBehaviour
{
    public GameObject Father;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Shark" || col.gameObject.name == "Muralla invisible") //|| col.gameObject.name == "Reset1" || col.gameObject.name == "Reset2")
        {
            GameObject.Find("Conexiones").GetComponent<Conexiones>().Colision(SceneManager.GetActiveScene().name);
            Father.GetComponent<Piezas_DragAndDrop>().placed = true;
            if (this.gameObject.name == "CuboRespuesta1")
            {
                Father.transform.position = new Vector3(-63.7f,-37.5f,96.6f);
            }
            else if (this.gameObject.name == "CuboRespuesta2")
            {
                Father.transform.position = new Vector3(-15.9f, -37.5f, 96.9f);
            }
            else if (this.gameObject.name == "CuboRespuesta3")
            {
                Father.transform.position = new Vector3(31.9f, -37.5f, 96.9f);
            }
            else if (this.gameObject.name == "CuboRespuesta4")
            {
                Father.transform.position = new Vector3(79.7f, -37.5f, 96.9f);
            }
            Invoke("UnlockPiece", 0.5f);
        }
    }
    void UnlockPiece()
    {
        Father.GetComponent<Piezas_DragAndDrop>().placed = false;
    }
}
