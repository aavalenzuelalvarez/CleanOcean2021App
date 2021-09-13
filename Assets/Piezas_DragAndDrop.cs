using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Piezas_DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public float z = 0.0f;
    public GameObject PlacePieza1, PlacePieza2,Father;
    public bool placed = false;
    public Text Respuesta1, Respuesta2;
    public int contador1=0, contador2=0;
    private int aux;
    public int final;
    
    void Start()
    {
        //final = 0;
        //contador1 = 0;
        //contador2 = 0;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (placed == false)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = z;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (placed == false)
        {
            if (this.gameObject.name == "PiezaRespuesta1")
            {
                this.transform.position = new Vector3(-63.7f, -37.5f, 96.9f);
            }
            else if (this.gameObject.name == "PiezaRespuesta2")
            {
                this.transform.position = new Vector3(-15.9f, -37.5f, 96.9f);
            }
            else if (this.gameObject.name == "PiezaRespuesta3")
            {
                this.transform.position = new Vector3(31.9f, -37.5f, 96.9f);
            }
            else if (this.gameObject.name == "PiezaRespuesta4")
            {
                this.transform.position = new Vector3(79.7f, -37.5f, 96.9f);
            }
        }
                   // transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        ////if (contador1 > Controlador_DragNDrop.respuesta1 || contador2 > Controlador_DragNDrop.respuesta2)
        ////{
        ////    final = 0;
        ////    GameObject.Find("Boton volver").SetActive(false);
        ////    GameObject.Find("Boton pausa").SetActive(false);
        ////    GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(Panel_incorrecto);
        ////    GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name);
        ////}
        ////else
        ////{
            if (placed == false)
            {
            //print("placed false");
                if ((transform.position != PlacePieza1.transform.position) && (transform.position != PlacePieza2.transform.position))
                {
                //print("posicion 1");

                if (((transform.position.x <= PlacePieza1.transform.position.x + 15) && (transform.position.x >= PlacePieza1.transform.position.x - 15)) && ((transform.position.y <= PlacePieza1.transform.position.y + 15) && (transform.position.y >= PlacePieza1.transform.position.y - 15)) && transform.Find("Animal").tag == Controlador_DragNDrop.a.tag)
                        {
                    //print("posicion 2");
                            if (contador1 == 0)
                            {
                                GameObject a = Instantiate(Father);
                                a.GetComponent<Piezas_DragAndDrop>().placed = true;
                                a.transform.position = PlacePieza1.transform.position;
                            }
                            placed = true;
                            if (this.gameObject.name == "PiezaRespuesta1")
                            {
                                transform.position = new Vector3(-63.7f, -37.5f, 96.6f);
                            }
                            else if (this.gameObject.name == "PiezaRespuesta2")
                            {
                                transform.position = new Vector3(-15.9f, -37.5f, 96.9f);
                            }
                            else if (this.gameObject.name == "PiezaRespuesta3")
                            {
                                transform.position = new Vector3(31.9f, -37.5f, 96.9f);
                            }
                            else if (this.gameObject.name == "PiezaRespuesta4")
                            {
                                transform.position = new Vector3(79.7f, -37.5f, 96.9f);
                            }
                            Invoke("UnlockedPiece", 1f);
                            contador1++;
                            Respuesta1.text = contador1.ToString();
                            if (Respuesta1.text == Controlador_DragNDrop.respuesta1.ToString())
                            {
                        //print("aaaaaaa");
                                final += 1;
                            }
                        }

                        if (((transform.position.x <= PlacePieza2.transform.position.x + 15) && (transform.position.x >= PlacePieza2.transform.position.x - 15)) && ((transform.position.y <= PlacePieza2.transform.position.y + 15) && (transform.position.y >= PlacePieza2.transform.position.y - 15)) && transform.Find("Animal").tag == Controlador_DragNDrop.c.tag)
                        {
                            if (contador2 == 0)
                            {
                                GameObject a = Instantiate(Father);
                                a.GetComponent<Piezas_DragAndDrop>().placed = true;
                                a.transform.position = PlacePieza2.transform.position;
                            }
                            placed = true;
                            if (this.gameObject.name == "PiezaRespuesta1")
                            {
                                transform.position = new Vector3(-63.7f, -37.5f, 96.6f);
                            }
                            else if (this.gameObject.name == "PiezaRespuesta2")
                            {
                                transform.position = new Vector3(-15.9f, -37.5f, 96.9f);
                            }
                            else if (this.gameObject.name == "PiezaRespuesta3")
                            {
                                transform.position = new Vector3(31.9f, -37.5f, 96.9f);
                            }
                            else if (this.gameObject.name == "PiezaRespuesta4")
                            {
                                transform.position = new Vector3(79.7f, -37.5f, 96.9f);
                            }
                            Invoke("UnlockedPiece", 1f);
                            contador2++;
                            Respuesta2.text = contador2.ToString();
                            if (Respuesta2.text == Controlador_DragNDrop.respuesta2.ToString())
                            {
                                final += 1;
                            }
                        }
                    }
            }
        }
   
    void UnlockedPiece()
    {
        placed = false;
    }
    }
