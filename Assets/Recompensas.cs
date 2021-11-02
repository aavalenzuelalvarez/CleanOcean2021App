using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Recompensas : MonoBehaviour
{
    public GameObject[] Animales, Animalaux = new GameObject[20], Basura = new GameObject[20];
    public int x,aux2;
    public static int porcentaje,act,contadoranimales;
    private GameObject Panel_recompensas1, Panel_correcto1, Panel_incorrecto1;
    private GameObject Rotatefish;
    public GameObject Slider;
    private Vector3 camerapos;
    public Conexiones conexiones;

    //Scene currentScene = SceneManager.GetActiveScene();
    // Start is called before the first frame update

    //void Awake()
    //{
    //    //if we don't have an [_instance] set yet
    //    if (!Recompensas)
    //        Recompensas = this;
    //    //otherwise, if we do, kill this thing
    //    else
    //        Destroy(this.gameObject);


    //    DontDestroyOnLoad(this.gameObject);
    //}

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (GameObject.Find(gameObject.name)
                  && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }

        if (SceneManager.GetActiveScene().name == "Progreso")
        {
            print(Animalaux.Length);
            for (x = 0; x <= 19; x++)
            {
                Animalaux[x] = GameObject.Find(Animales[x].name);
                Animalaux[x].SetActive(false);
            }
            for (x = 0; x <= 19; x++)
            {

                //Basura[x] = GameObject.Find("basura" + (x + 1).ToString());
                //print(x);
                Basura[x].SetActive(false);
            }
        }

    }
    private void Start()
    {
        //GameObject.Find("Button_test").GetComponent<TestRecompensa>().ClickRecompensa();
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Progreso")
        {
            PorcentajeProgreso();
        }
        porcentaje = BarraProgreso.act;
        ////////////////////////////////////////
        //if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        //{
        //    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit raycastHit;
        //    if (Physics.Raycast(raycast, out raycastHit))
        //    {
        //        print(raycastHit.collider.name);
        //        print(raycastHit.collider.gameObject.layer);
        //        if (raycastHit.collider.gameObject.layer == 12)
        //        {
        //            SceneManager.LoadScene("Progreso");
        //        }
        //    }
        //}
        /////////////////////////////////////////
    }

    public void Recompensa(GameObject Panel_recompensas, GameObject Panel_correcto)
    {

            if (contadoranimales < 95)
            {
                BarraProgreso.act += 5;
            }
            if (contadoranimales == 20)
            {
                aux2 = 20;
                contadoranimales = 0;
            }
                Panel_correcto1 = Panel_correcto;
                Panel_recompensas1 = Panel_recompensas;
                Panel_correcto.gameObject.SetActive(true);
                // Invoke("MostrarRecompensa", 3f);
                //a.transform.position = camerapos;
                //if (contadoranimales == 4) //pulpo
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 0.97f, a.transform.position.z + 300f);
                //}
                //else if (contadoranimales == 5)
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 3.6f, a.transform.position.z + 300f);
                //}
                //else if (contadoranimales == 10)
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 3.2f, a.transform.position.z + 300f);
                //}
                //else if (contadoranimales == 11)
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 2.8f, a.transform.position.z + 300f);
                //}
                //else if (contadoranimales == 12)
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 2.3f, a.transform.position.z + 300f);
                //}
                //else
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x+4.76f, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 19.8f, a.transform.position.z+300f);
                //}
                //if (contadoranimales == 4) //pulpo
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 0.97f, GameObject.Find("Main Camera").GetComponent<Transform>().position.z + 10.2f);
                //}
                //else if (contadoranimales == 5)
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 3.6f, GameObject.Find("Main Camera").GetComponent<Transform>().position.z + 17.46f);
                //}
                //else if (contadoranimales == 10)
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 3.2f, GameObject.Find("Main Camera").GetComponent<Transform>().position.z + 19.51f);
                //}
                //else if (contadoranimales == 11)
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 2.8f, GameObject.Find("Main Camera").GetComponent<Transform>().position.z + 13.5f);
                //}
                //else if (contadoranimales == 12)
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 2.3f, GameObject.Find("Main Camera").GetComponent<Transform>().position.z + 15.7f);
                //}
                //else
                //{
                //    a.transform.position = new Vector3(GameObject.Find("Main Camera").GetComponent<Transform>().position.x, GameObject.Find("Main Camera").GetComponent<Transform>().position.y - 1.4f, GameObject.Find("Main Camera").GetComponent<Transform>().position.z + 8.16f);
                //}

        }
    void PorcentajeProgreso()
    {
        if (aux2 != 20)
        {
            BarraProgreso.act = contadoranimales * 5;
        }
        else
        {
            Slider.SetActive(false);
        }
        // for (x = contadoranimales - 1; x >= 0; x--)
        // {
        //     Animalaux[x].SetActive(true);
        // }
        for (x = contadoranimales; x <= 19; x++)
        {
            Basura[x].SetActive(true);
        }
        //  print(aux);
    }
    
    public void Incorrecto(GameObject Panel_incorrecto)
    {
        Panel_incorrecto.SetActive(true);
        Invoke("RestartScene", 3f);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MostrarRecompensa()
    {
        Panel_correcto1.gameObject.SetActive(false);
        Panel_recompensas1.gameObject.SetActive(true);
        //camerapos = GameObject.Find("Main Camera").GetComponent<Transform>().position;
        if (SceneManager.GetActiveScene().name == "Actividad Lancha")
        {
            GameObject.Find("Main Camera").GetComponent<Camtest1>().enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Actividad Laberinto")
        {
            GameObject.Find("Main Camera").GetComponent<CameraMotor>().enabled = false;
        }
        GameObject.Find("Main Camera").GetComponent<Transform>().rotation = Quaternion.Euler(0f, 0f, 0f);
        GameObject.Find("Main Camera").GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
        // GameObject a = Instantiate(Animales[contadoranimales]) as GameObject;
        // a.GetComponent<swimFish>().enabled = false;
        // a.gameObject.SetActive(false);
        // if (contadoranimales == 2)
        // {
        //     GameObject.Find("Main Camera").GetComponent<Camera>().farClipPlane = 500;
        //     a.transform.position = new Vector3(0, -30, 145);
        // }
        // else if (contadoranimales == 5)
        // {
        //     GameObject.Find("Main Camera").GetComponent<Camera>().farClipPlane = 500;
        //     a.transform.position = new Vector3(0, -56.4f, 318.32f);
        // }
        // else if (contadoranimales == 8)
        // {
        //     GameObject.Find("Main Camera").GetComponent<Camera>().farClipPlane = 500;
        //     a.transform.position = new Vector3(0, -22.4f, 101.21f);
        // }
        // else if (contadoranimales == 10)
        // {
        //     GameObject.Find("Main Camera").GetComponent<Camera>().farClipPlane = 1500;
        //     a.transform.position = new Vector3(0, -135, 1084.9f);
            
        // }
        // else if (contadoranimales == 11)
        // {
        //     GameObject.Find("Main Camera").GetComponent<Camera>().farClipPlane = 1500;
        //     a.transform.position = new Vector3(0, -113.9f, 763.5f);
        // }
        // else if (contadoranimales == 12)
        // {
        //     GameObject.Find("Main Camera").GetComponent<Camera>().farClipPlane = 1500;
        //     a.transform.position = new Vector3(0, -74.5f, 709.71f);
        // }
        // else if (contadoranimales == 18)
        // {
        //     GameObject.Find("Main Camera").GetComponent<Camera>().farClipPlane = 1500;
        //     a.transform.position = new Vector3(45.8f, -38.9f, 352.7f);
        // }
        // else
        // {
        //     GameObject.Find("Main Camera").GetComponent<Camera>().farClipPlane = 500;
        //     a.transform.position = new Vector3(0, -30, 200); // POR CADA ANIMAL
        // }

        // a.GetComponent<Rotatefish>().enabled = true;
        // a.AddComponent<Button>();
        // a.GetComponent<Button>().onClick.AddListener(delegate{GameObject.Find("Animales").GetComponent<Recompensas>().Home();});
        // a.gameObject.SetActive(true);
        Panel_recompensas1.AddComponent<Button>();
        GameObject.Find("TiempoxActividad").GetComponent<TiempoXActividad>().TerminoActividad();
        Panel_recompensas1.GetComponent<Button>().onClick.AddListener(delegate{GameObject.Find("Animales").GetComponent<Recompensas>().Home();});
        //GameObject.Find("Conexiones").GetComponent<Conexiones>().FTimeRecompensa();
        contadoranimales += 1;
        print("contadoranimales" + contadoranimales);
        Invoke("RestartScene", 5f);
        //if (contadoranimales=

    }

    public void Home()
    {
        SceneManager.LoadScene("CargaMenu");
    }
    
    
}

