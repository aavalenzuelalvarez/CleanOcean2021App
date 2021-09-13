using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class Patron : MonoBehaviour
{
    // Start is called before the first frame update
    // AlumnoRespuestaActividad respuestacorrecta = new AlumnoRespuestaActividad();
    public GameObject[] Burbujas, Animales, Respuesta;
    public GameObject panelcorrecto, panelincorrecto, panelrecompensa;
    public int secuencia;
    private int animal1, animal2, contador, i=0, total, aux=0;
    void Start()
    {
        
        secuencia = Random.Range(0, 6);
        animal1 = Random.Range(0, 6);
        animal2 = Random.Range(0, 6);
        secuencia = 1;
        while (animal1 == animal2)
        {
            animal2 = Random.Range(0, 6);
        }
        GameObject a = Instantiate(Animales[animal1]) as GameObject;
        GameObject b = Instantiate(Animales[animal2]) as GameObject;
        //a.GetComponent<Button>().onClick.RemoveListener();
        //a.onClick.RemoveListener("")
        print("animal1 : " + animal1);
        print("animal2 : " + animal2);
        if (secuencia == 0) // 1 - 1 - 1 - 1 ...
        {
            //contador = 2;
            //GameObject c = Instantiate(Animales[animal1]) as GameObject;
            if (animal1 == 5)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x+2.7f, Burbujas[0].GetComponent<Transform>().position.y+0.8f, Burbujas[0].GetComponent<Transform>().position.z-6);
                //c.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x + 2.7f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z - 6);
            }
            else if (animal1 == 4)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x - 10f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z);
                //c.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x - 10f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z);
            }
            else
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x, Burbujas[0].GetComponent<Transform>().position.y, Burbujas[0].GetComponent<Transform>().position.z);
                //c.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x, Burbujas[2].GetComponent<Transform>().position.y, Burbujas[2].GetComponent<Transform>().position.z);
            }
            if (animal2 == 5)
            {
                b.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x + 2.7f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z - 6);
            }
            else if (animal2 == 4)
            {
                b.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x - 10f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z);
            }
            else
            {
                b.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x, Burbujas[1].GetComponent<Transform>().position.y, Burbujas[1].GetComponent<Transform>().position.z);
            }

        }
        else if (secuencia == 1) // 1 - 2 - 1 - 2 - 1 - 2
        {
            contador = 3;
            //GameObject c = Instantiate(Animales[animal1]) as GameObject;
            GameObject d = Instantiate(Animales[animal2]) as GameObject;
            if (animal1 == 5)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x + 2.7f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z - 6);
                //c.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x + 2.7f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[3].GetComponent<Transform>().position.z - 6);
            }
            else if (animal1 == 4)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x - 10f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z);
                //c.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x - 10f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[3].GetComponent<Transform>().position.z);
            }
            else
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x, Burbujas[0].GetComponent<Transform>().position.y, Burbujas[0].GetComponent<Transform>().position.z);
                //c.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x, Burbujas[3].GetComponent<Transform>().position.y, Burbujas[3].GetComponent<Transform>().position.z);
            }
            if (animal2 == 5)
            {
                b.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x + 2.7f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z - 6);
                d.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x + 2.7f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z - 6);
            }
            else if (animal2 == 4)
            {
                b.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x - 10f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z);
                d.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x - 10f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z);
            }
            else
            {
                b.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x, Burbujas[1].GetComponent<Transform>().position.y, Burbujas[1].GetComponent<Transform>().position.z);
                d.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x, Burbujas[2].GetComponent<Transform>().position.y, Burbujas[2].GetComponent<Transform>().position.z);
            }
        }
        else if (secuencia == 2) // 3 - 1 - 3 - 1
        {
            GameObject c = Instantiate(Animales[animal1]) as GameObject;
            GameObject d = Instantiate(Animales[animal1]) as GameObject;
            //GameObject e = Instantiate(Animales[animal1]) as GameObject;
            contador = 4;
            if (animal1 == 5)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x + 2.7f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z - 6);
                c.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x + 2.7f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z - 6);
                d.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x + 2.7f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z - 6);
                //e.transform.position = new Vector3(Burbujas[4].GetComponent<Transform>().position.x + 2.7f, Burbujas[4].GetComponent<Transform>().position.y + 0.8f, Burbujas[4].GetComponent<Transform>().position.z - 6);
            }
            else if (animal1 == 4)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x - 10f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z);
                c.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x - 10f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z);
                d.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x - 10f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z);
                //e.transform.position = new Vector3(Burbujas[4].GetComponent<Transform>().position.x - 10f, Burbujas[4].GetComponent<Transform>().position.y + 0.8f, Burbujas[4].GetComponent<Transform>().position.z);
                
            }
            else
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x, Burbujas[0].GetComponent<Transform>().position.y, Burbujas[0].GetComponent<Transform>().position.z);
                c.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x, Burbujas[1].GetComponent<Transform>().position.y, Burbujas[1].GetComponent<Transform>().position.z);
                d.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x, Burbujas[2].GetComponent<Transform>().position.y, Burbujas[2].GetComponent<Transform>().position.z);
                //e.transform.position = new Vector3(Burbujas[4].GetComponent<Transform>().position.x, Burbujas[4].GetComponent<Transform>().position.y, Burbujas[4].GetComponent<Transform>().position.z);
            }
            if (animal2 == 5)
            {
                b.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x + 2.7f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[3].GetComponent<Transform>().position.z - 6);
            }
            else if (animal2 == 4)
            {
                b.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x - 10f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[3].GetComponent<Transform>().position.z);
            }
            else
            {
                b.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x, Burbujas[3].GetComponent<Transform>().position.y, Burbujas[3].GetComponent<Transform>().position.z);
            }
        }
        else if (secuencia == 3) // 1 - 3 - 1 - 3
        {
            GameObject c = Instantiate(Animales[animal2]) as GameObject;
            GameObject d = Instantiate(Animales[animal2]) as GameObject;
            //GameObject e = Instantiate(Animales[animal1]) as GameObject;
            contador = 4;
            if (animal1 == 5)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x + 2.7f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z - 6);
                //e.transform.position = new Vector3(Burbujas[4].GetComponent<Transform>().position.x + 2.7f, Burbujas[4].GetComponent<Transform>().position.y + 0.8f, Burbujas[4].GetComponent<Transform>().position.z - 6);
            }
            else if (animal1 == 4)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x - 10f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z);
                //e.transform.position = new Vector3(Burbujas[4].GetComponent<Transform>().position.x - 10f, Burbujas[4].GetComponent<Transform>().position.y + 0.8f, Burbujas[4].GetComponent<Transform>().position.z);
            }
            else
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x, Burbujas[0].GetComponent<Transform>().position.y, Burbujas[0].GetComponent<Transform>().position.z);
                //e.transform.position = new Vector3(Burbujas[4].GetComponent<Transform>().position.x, Burbujas[4].GetComponent<Transform>().position.y, Burbujas[4].GetComponent<Transform>().position.z);
            }

            if (animal2 == 5)
            {
                b.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x + 2.7f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z - 6);
                c.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x + 2.7f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z - 6);
                d.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x + 2.7f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[3].GetComponent<Transform>().position.z - 6);            }
            else if (animal2 == 4)
            {
                b.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x - 10f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z);
                c.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x - 10f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z);
                d.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x - 10f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[3].GetComponent<Transform>().position.z);
            }
            else
            {
                b.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x, Burbujas[1].GetComponent<Transform>().position.y, Burbujas[1].GetComponent<Transform>().position.z);
                c.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x, Burbujas[2].GetComponent<Transform>().position.y, Burbujas[2].GetComponent<Transform>().position.z);
                d.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x, Burbujas[3].GetComponent<Transform>().position.y, Burbujas[3].GetComponent<Transform>().position.z);
            }
        }
        else if (secuencia == 4) // 2 - 1 - 2 - 1 -2
        {
            GameObject c = Instantiate(Animales[animal1]) as GameObject;
            //GameObject d = Instantiate(Animales[animal1]) as GameObject;
            contador = 3;
            if (animal1 == 5)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x + 2.7f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z - 6);
                c.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x + 2.7f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z - 6);
                //d.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x + 2.7f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[3].GetComponent<Transform>().position.z - 6);
            }
            else if (animal1 == 4)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x - 10f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z);
                c.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x - 10f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z);
                //d.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x - 10f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[3].GetComponent<Transform>().position.z);
            }
            else
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x, Burbujas[0].GetComponent<Transform>().position.y, Burbujas[0].GetComponent<Transform>().position.z);
                c.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x, Burbujas[1].GetComponent<Transform>().position.y, Burbujas[1].GetComponent<Transform>().position.z);
                //d.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x, Burbujas[3].GetComponent<Transform>().position.y, Burbujas[3].GetComponent<Transform>().position.z);
            }
            if (animal2 == 5)
            {
                b.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x + 2.7f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z - 6);
            }
            else if (animal2 == 4)
            {
                b.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x - 10f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z);
            }
            else
            {
                b.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x, Burbujas[2].GetComponent<Transform>().position.y, Burbujas[2].GetComponent<Transform>().position.z);
            }
        }
        else if (secuencia == 5) // 2 - 2 - 2 - 2
        {
            GameObject c = Instantiate(Animales[animal1]) as GameObject;
            //GameObject d = Instantiate(Animales[animal1]) as GameObject;
            GameObject e = Instantiate(Animales[animal2]) as GameObject;
            contador = 4;
            if (animal1 == 5)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x + 2.7f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z - 6);
                c.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x + 2.7f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z - 6);
                //d.transform.position = new Vector3(Burbujas[4].GetComponent<Transform>().position.x + 2.7f, Burbujas[4].GetComponent<Transform>().position.y + 0.8f, Burbujas[4].GetComponent<Transform>().position.z - 6);
            }
            else if (animal1 == 4)
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x - 10f, Burbujas[0].GetComponent<Transform>().position.y + 0.8f, Burbujas[0].GetComponent<Transform>().position.z);
                c.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x - 10f, Burbujas[1].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z);
                //d.transform.position = new Vector3(Burbujas[4].GetComponent<Transform>().position.x - 10f, Burbujas[4].GetComponent<Transform>().position.y + 0.8f, Burbujas[4].GetComponent<Transform>().position.z);
            }
            else
            {
                a.transform.position = new Vector3(Burbujas[0].GetComponent<Transform>().position.x, Burbujas[0].GetComponent<Transform>().position.y, Burbujas[0].GetComponent<Transform>().position.z);
                c.transform.position = new Vector3(Burbujas[1].GetComponent<Transform>().position.x, Burbujas[1].GetComponent<Transform>().position.y, Burbujas[1].GetComponent<Transform>().position.z);
                //d.transform.position = new Vector3(Burbujas[4].GetComponent<Transform>().position.x, Burbujas[4].GetComponent<Transform>().position.y, Burbujas[4].GetComponent<Transform>().position.z);
            }
            if (animal2 == 5)
            {
                b.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x + 2.7f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z - 6);
                e.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x + 2.7f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[1].GetComponent<Transform>().position.z - 6);
            }
            else if (animal2 == 4)
            {
                b.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x - 10f, Burbujas[2].GetComponent<Transform>().position.y + 0.8f, Burbujas[2].GetComponent<Transform>().position.z);
                e.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x - 10f, Burbujas[3].GetComponent<Transform>().position.y + 0.8f, Burbujas[3].GetComponent<Transform>().position.z);
            }
            else
            {
                b.transform.position = new Vector3(Burbujas[2].GetComponent<Transform>().position.x, Burbujas[2].GetComponent<Transform>().position.y, Burbujas[2].GetComponent<Transform>().position.z);
                e.transform.position = new Vector3(Burbujas[3].GetComponent<Transform>().position.x, Burbujas[3].GetComponent<Transform>().position.y, Burbujas[3].GetComponent<Transform>().position.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(contador);
        if (contador == 8)
        {
            if (secuencia == 0)
            {
                if (aux == 0)
                {
                    if (Respuesta[0].name==Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[1].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (Respuesta[2].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[3].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (Respuesta[4].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[5].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (total == 6)
                    {
                        Hide();
                        GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(panelrecompensa, panelcorrecto);
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto("Actividad Patrones");
                        RespuestaFinalCorrecta();
                    }
                    else
                    {
                        Hide();
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto("Actividad Patrones");
                        GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(panelincorrecto);
                        RespuestaFinalIncorrecta();
                        print("incorrecto");
                    }
                    aux++;
                }
            }
            else if (secuencia == 1)
            {
                if (aux == 0)
                {
                    if (Respuesta[0].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[1].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (Respuesta[2].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (Respuesta[3].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[4].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (total == 5)
                    {
                        Hide();
                        GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(panelrecompensa, panelcorrecto);
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto("Actividad Patrones");
                        RespuestaFinalCorrecta();
                    }
                    else
                    {
                        Hide();
                        GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(panelincorrecto);
                        print("incorrecto");
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto("Actividad Patrones");
                        RespuestaFinalIncorrecta();
                    }
                    aux++;
                }
            }
            else if (secuencia == 2)
            {
                if (aux == 0)
                {
                    if (Respuesta[0].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[1].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[2].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[3].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (total == 4)
                    {
                        Hide();
                        GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(panelrecompensa, panelcorrecto);
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto("Actividad Patrones");
                        RespuestaFinalCorrecta();
                    }
                    else
                    {
                        Hide();
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto("Actividad Patrones");
                        GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(panelincorrecto);
                        RespuestaFinalIncorrecta();
                        print("incorrecto");
                    }
                    aux++;
                }
            }
            else if (secuencia == 3)
            {
                if (aux == 0)
                {
                    if (Respuesta[0].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[1].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (Respuesta[2].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (Respuesta[3].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (total == 4)
                    {
                        Hide();
                        GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(panelrecompensa, panelcorrecto);
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto("Actividad Patrones");
                        RespuestaFinalCorrecta();
                    }
                    else
                    {
                        Hide();
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto("Actividad Patrones");
                        GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(panelincorrecto);
                        RespuestaFinalIncorrecta();
                        print("incorrecto");
                    }
                    aux++;
                }
            }
            else if (secuencia == 4)
            {
                if (aux == 0)
                {
                    if (Respuesta[0].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[1].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[2].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (Respuesta[3].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[4].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (total == 5)
                    {
                        Hide();
                        GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto("Actividad Patrones");
                        // GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(panelrecompensa, panelcorrecto);
                        RespuestaFinalCorrecta();
                    }
                    else
                    {
                        Hide();
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto("Actividad Patrones");
                        GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(panelincorrecto);
                        RespuestaFinalIncorrecta();
                        print("incorrecto");
                    }
                    aux++;
                }
            }
            else if (secuencia == 5)
            {
                if (aux == 0)
                {
                    if (Respuesta[0].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[1].name == Animales[animal1].name)
                    {
                        total++;
                    }
                    if (Respuesta[2].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (Respuesta[3].name == Animales[animal2].name)
                    {
                        total++;
                    }
                    if (total == 4)
                    {
                        Hide();
                        GameObject.Find("Animales").GetComponent<Recompensas>().Recompensa(panelrecompensa, panelcorrecto);
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaCorrecto("Actividad Patrones");
                        RespuestaFinalCorrecta();
                    }
                    else
                    {
                        Hide();
                        // GameObject.Find("Conexiones").GetComponent<Conexiones>().AlmacenaIncorrecto("Actividad Patrones");
                        GameObject.Find("Animales").GetComponent<Recompensas>().Incorrecto(panelincorrecto);
                        RespuestaFinalIncorrecta();
                        print("incorrecto");
                    }
                    aux++;
                }
            }
        }
        
    }

    public void RespuestaFinalCorrecta(){
        Respuesta respuestacorrecta = new Respuesta();
        respuestacorrecta.id_per = 202101;
        respuestacorrecta.id_user = int.Parse(Conexiones.id_user);
        respuestacorrecta.id_reim = 500;
        respuestacorrecta.id_actividad = 3007;
        respuestacorrecta.id_elemento = 3059;
        System.DateTime ahora = System.DateTime.Now;
        respuestacorrecta.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        respuestacorrecta.Eje_X = gameObject.transform.position.x;
        respuestacorrecta.Eje_Y = gameObject.transform.position.y;
        respuestacorrecta.Eje_Z = 0;
        respuestacorrecta.correcta = 1;
        respuestacorrecta.resultado = "Correcto";
        respuestacorrecta.Tipo_Registro = 0;
        StartCoroutine(PostAddPatrones(respuestacorrecta));
    }

    public void RespuestaFinalIncorrecta(){
        Respuesta respuestaincorrecta = new Respuesta();
        respuestaincorrecta.id_per = 202101;
        respuestaincorrecta.id_user = int.Parse(Conexiones.id_user);
        respuestaincorrecta.id_reim = 500;
        respuestaincorrecta.id_actividad = 3007;
        respuestaincorrecta.id_elemento = 3059;
        System.DateTime ahora = System.DateTime.Now;
        respuestaincorrecta.datetime_touch = ahora.ToString("yyyy-MM-dd HH:mm:ss.ffffff");
        respuestaincorrecta.Eje_X = gameObject.transform.position.x;
        respuestaincorrecta.Eje_Y = gameObject.transform.position.y;
        respuestaincorrecta.Eje_Z = 0;
        respuestaincorrecta.correcta = 0;
        respuestaincorrecta.resultado = "Incorrecto";
        respuestaincorrecta.Tipo_Registro = 0;
        StartCoroutine(PostAddPatrones(respuestaincorrecta));
    }
    public IEnumerator PostAddPatrones(Respuesta respueston)
    {
        string urlAPI = "http://localhost:3002/api/alumno_respuesta/add";
        var jsonData = JsonUtility.ToJson(respueston);
        //Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Post(urlAPI, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                Debug.Log("Error");
            }
            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    if (result != null)
                    {
                        //var id_txa = JsonUtility.FromJson<String>(result);
                        //Debug.Log(id_txa);
                    }
                }
            }
        }
    }

    public void PressObject(GameObject Animal)
    {
        if (contador < 8)
        {
            if (Animal.name == "Caracola")
            {
                GameObject respuesta = Instantiate(Animal);
                respuesta.transform.position = new Vector3(Burbujas[contador].GetComponent<Transform>().position.x + 2.7f, Burbujas[contador].GetComponent<Transform>().position.y + 0.8f, Burbujas[contador].GetComponent<Transform>().position.z - 6);
            }
            else if (Animal.name == "Cangrejo Hermitaño")
            {
                GameObject respuesta = Instantiate(Animal);
                respuesta.transform.position = new Vector3(Burbujas[contador].GetComponent<Transform>().position.x - 10f, Burbujas[contador].GetComponent<Transform>().position.y + 0.8f, Burbujas[contador].GetComponent<Transform>().position.z);
            }
            else
            {
                GameObject respuesta = Instantiate(Animal);
                respuesta.transform.position = new Vector3(Burbujas[contador].GetComponent<Transform>().position.x, Burbujas[contador].GetComponent<Transform>().position.y, Burbujas[contador].GetComponent<Transform>().position.z);
            }
            print ("NOMBRE ANIMAL" + Animal.name);
            contador++;
            Respuesta[i] = Animal;
            i++;
        }
    }
    public void Hide ()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Ocultar");
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
    }
}
