using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaAGetCantidad : MonoBehaviour
{
    public SistemaNaves _sistemaNaves;
    public void Start()
    {
        BarraProgreso.act = 0;
        SistemaNaves.contAnimales = 0;
        _sistemaNaves.cargarNaves();
    }

}
