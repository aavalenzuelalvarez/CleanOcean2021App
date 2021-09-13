using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menosanimales : MonoBehaviour
{
    private GameObject Slider,Positionnull;
    private GameObject[] basura,animales;
    private int x;
    private string[] nombres = { "Redear_sunfish_prefab", "Yellow_boxfish_prefab", "Clownfish_prefab", "Foureye_butterflyfish_prefab", "Octopus_prefab", "Giant_squid_prefab", "Sunfish_prefab", "Lionfish_prefab", "Stingray_prefab", "Green_turtle_prefab", "Whale2", "Great_white_shark_prefab", "Orca_prefab", "Salmon_prefab", "SardinePrefab Variant", "Moorish_idol_prefab", "Purplefish_prefab", "Dolphin_prefab", "Bull_shark_prefab", "Salmon_old_prefab", };
    public int countmenos;
    // Start is called before the first frame update
    void Start()
    {
        Slider = GameObject.Find("Slider");
        basura = new GameObject[21];
        animales = new GameObject[21];
        //nombres = { "Redear_sunfish_prefab", "Yellow_boxfish_prefab", "Clownfish_prefab", "Foureye_butterflyfish_prefab", "Octopus_prefab", "Giant_squid_prefab", "Sunfish_prefab", "Lionfish_prefab", "Stingray_prefab","Green_turtle_prefab", "Whale2", "Great_white_shark_prefab", "Orca_prefab", "Salmon_prefab", "SardinePrefab Variant", "Moorish_idol_prefab", "Purplefish_prefab", "Dolphin_prefab", "Bull_shark_prefab", "Salmon_old_prefab"};
        for (x = 0; x < 20; x++)
        {
            basura[x] = GameObject.Find("Basura" + (x + 1).ToString());
            animales[x] = GameObject.Find(nombres[x]);
        }
        //animales[0] = GameObject.Find(nombres[0]);
        Positionnull = GameObject.Find("Posicion_oculta");

    }

    // Update is called once per frame
    void Update()
    {
        x = ((BarraProgreso.act / 5));


    }
    public void disminuiranimales()
    {
        if (BarraProgreso.act >= 5)
        {
            if (x == 20)
            {
                x -= 1;
            }
            basura[x].SetActive(true);
            BarraProgreso.act -= 5;
            countmenos += 1;
            x -= 1;
        }

    }
}