using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoLancha : MonoBehaviour
{
    public Conexiones conexiones;
    public float g = 9.8f,positiony;
    public float speed = 10;
    public int colisiones=0,aux=0,x;
    public Material Skybox;
    public GameObject Panel_correcto, Panel_incorrecto, Panel_recompensa;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (colisiones >= 20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            speed = 0;
            GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name);
            GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(Panel_incorrecto);
            colisiones = 0;
        }
        if (colisiones <= 20 && GetComponent<Transform>().position.z >= GameObject.Find("Isla actLancha").GetComponent<Transform>().position.z - 58 && aux==0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            speed = 0;
            GameObject.Find("Main Camera").GetComponent<Skybox>().enabled = false;
            RenderSettings.skybox = Skybox;
            GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name);
            GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(Panel_recompensa,Panel_correcto);
            conexiones.UpdateTimeActividad(1);
            colisiones = 0;
            aux += 1;
        }
        
        
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (speed < 20)
        {
            speed += 0.005f;
        }
        // normalize axis
        var gravity = new Vector2(Input.acceleration.x, 0) * g;
        GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
        GetComponent<Transform>().rotation = new Quaternion (0.0f, 0.0f, 0.0f, 0.0f);
        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, 0.69f, GetComponent<Transform>().position.z);

    }
    private void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.name == "BasuraPrefab") || (col.gameObject.name == "RuedaPrefab") || (col.gameObject.name == "BarrilPrefab"))
        {
            GameObject.Find("Conexiones").GetComponent<Conexiones>().Colision(SceneManager.GetActiveScene().name, col.gameObject.name);
            x = Random.Range(-285, -163);
            if (gameObject.name == "BasuraPrefab")
            {
                positiony = -0.63f;
            }
            else if (gameObject.name == "RuedaPrefab")
            {
                positiony = -0.3f;
            }
            else if (gameObject.name == "BasuraPrefab")
            {
                positiony = -0.4f;
            }
            if (col.transform.position.z + 200 < GameObject.Find("Isla actLancha").GetComponent<Transform>().position.z - 58)
            {
                col.transform.position = new Vector3(x, positiony, GetComponent<Transform>().position.z + 200);
            }
            colisiones++;
            print(colisiones);
        }
    }
}
