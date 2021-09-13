using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoAct : MonoBehaviour
{
    public GameObject PanelInstrucciones;
    private int x = 1;
    // Start is called before the first frame update

    void Start()
    {

    }
    public void Mostrar()
    {
        if (x == 1){
            PanelInstrucciones.SetActive(true);
            x *= -1;
        } else
        {
            PanelInstrucciones.SetActive(false);
            x *= -1;
        }
        
    }
}

