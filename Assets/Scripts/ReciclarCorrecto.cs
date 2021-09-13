using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciclarCorrecto : MonoBehaviour
{

    public GameObject[] Botones;
    private int i;
    public GameObject PanelCorrecto;
    // Start is called before the first frame update
    void Start()
    {
        for (i=0; i <= Botones.Length-1; i++)
        {
            Botones[i].SetActive(true);
        }
        PanelCorrecto.gameObject.SetActive(false);
        PanelCorreccionCerrar.contadordebasura = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PanelCorreccionCerrar.contadordebasura == 5){
            PanelCorrecto.gameObject.SetActive(true);
            EsconderTodo();
        }
    }

    public void EsconderTodo(){
        for (i=0; i <= Botones.Length-1; i++)
        {
            Botones[i].SetActive(false);
        }
    }
}
