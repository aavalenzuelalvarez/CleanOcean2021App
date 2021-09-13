using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarenPanelCorrecto : MonoBehaviour
{
    public GameObject PanelCorrecto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReiniciarJuegoCorrecto()
    {
        PanelCorrecto.SetActive(false);
        // SceneManager.LoadScene("CargaReciclar");
    }
}
