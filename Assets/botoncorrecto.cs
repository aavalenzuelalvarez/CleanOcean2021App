using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class botoncorrecto : MonoBehaviour
{
    public Button btn;
    public GameObject correcto, incorrecto,pregunta,respuestas, recompensa;
    public int aux2;
    // Start is called before the first frame update
    void Start()
    {
        aux2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameObject.Find("Main Camera").GetComponent<deployFish>().count== 3)
        //{
        //    isCorrect();
        //}
    }
    public void isCorrect()
    {
        //Debug.Log(GameObject.Find("Main Camera").GetComponent<deployFish>().respuestacorrecta.ToString());
        pregunta.gameObject.SetActive(false);
        var aux = GameObject.Find("Moorish_idol_prefab(Clone)");
        if (aux == null)
        {
            aux = GameObject.Find("Blue_tang_prefab(Clone)");
            if (aux == null)
            {
                aux = GameObject.Find("Salmon_prefab(Clone)");
                if (aux == null)
                {
                    aux = GameObject.Find("Clownfish_prefab(Clone)");

                    if (aux == null)
                    {
                        aux = GameObject.Find("Green_turtle_prefab(Clone)");
                    }
                }
            }
        }
        aux.SetActive(false);


        if (btn.GetComponentInChildren<Text>().text == (GameObject.Find("Main Camera").GetComponent<deployFish>().respuestacorrecta).ToString() && aux2 == 0)
        {
            correcto.gameObject.SetActive(true);
            btn.GetComponent<Image>().color = Color.green;
            respuestas.gameObject.SetActive(false);
            GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto(SceneManager.GetActiveScene().name, gameObject.name);
            Invoke("MostrarRecompensa", 3f);
            aux2 += 1;
            
            
        }
        else if (btn.GetComponentInChildren<Text>().text != (GameObject.Find("Main Camera").GetComponent<deployFish>().respuestacorrecta).ToString() && aux2 == 0)
        {
            //incorrecto.gameObject.SetActive(true);
            respuestas.gameObject.SetActive(false);
            GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(incorrecto);
            GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto(SceneManager.GetActiveScene().name, gameObject.name);
            //Invoke("ReiniciarAct", 3f);
            aux2 += 1;
        }
        
    }
    private void MostrarRecompensa()
    {
        correcto.gameObject.SetActive(false);
        GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(recompensa,correcto);
    }
    private void ReiniciarAct()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
