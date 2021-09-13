using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaMenu : MonoBehaviour
{
    // Start is called before the first frame update
    // public Conexiones conexiones;
    
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void CargaNivel(string pnombreNivel)
    {
        SceneManager.LoadScene(pnombreNivel);
        // GameObject.Find("Conexiones").GetComponent<Conexiones>().FTimeVolver();

    }
    //public void alCarga(){
    //   SceneManager.LoadScene(nombre_escena);    
//}
}
