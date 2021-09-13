using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingbar : MonoBehaviour {

    public Transform BarraEspera;
    public Transform TextProgreso;
    public Transform TextCargando;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;
    [SerializeField] private string nombre_escena;

   void Update()
    {
        if (currentAmount < 100){
            currentAmount += speed * Time.deltaTime;
            TextProgreso.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            TextCargando.gameObject.SetActive(true);
        } else{
            TextCargando.gameObject.SetActive(false);
            TextProgreso.GetComponent<Text>().text = "Ya casi";
            SceneManager.LoadScene(nombre_escena);
        }
        BarraEspera.GetComponent<Image>().fillAmount = currentAmount / 100; 
    }

    /*private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.0f;
    public string nombre_escena;


    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
    }

    void Update()
    {
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            
        }
        else
        {
            imageComp.fillAmount = 0.0f;
            SceneManager.LoadScene(nombre_escena);

        }
    }*/
}
