//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ControldeAnimales : MonoBehaviour
//{
//    private GameObject Slider;
//    private GameObject[] basura;
//    public GameObject[] animales;
//    private string[] nombres = { "Redear_sunfish_prefab", "Yellow_boxfish_prefab", "Clownfish_prefab", "Foureye_butterflyfish_prefab", "Octopus_prefab", "Giant_squid_prefab", "Sunfish_prefab", "Lionfish_prefab", "Stingray_prefab", "Green_turtle_prefab", "Whale2", "Great_white_shark_prefab", "Orca_prefab", "Salmon_prefab", "SardinePrefab Variant", "Moorish_idol_prefab", "Purplefish_prefab", "Dolphin_prefab", "Bull_shark_prefab", "Salmon_old_prefab"};
//    private int x,i;
//    public int count=1;
//    // Start is called before the first frame update
//    void Start()
//    {
//        Slider = GameObject.Find("Slider");
//        basura = new GameObject[20];
//        animales = new GameObject[20];
//        //nombres = { "Redear_sunfish_prefab", "Yellow_boxfish_prefab", "Clownfish_prefab", "Foureye_butterflyfish_prefab", "Octopus_prefab", "Giant_squid_prefab", "Sunfish_prefab", "Lionfish_prefab", "Stingray_prefab","Green_turtle_prefab", "Whale2", "Great_white_shark_prefab", "Orca_prefab", "Salmon_prefab", "SardinePrefab Variant", "Moorish_idol_prefab", "Purplefish_prefab", "Dolphin_prefab", "Bull_shark_prefab", "Salmon_old_prefab"};
//        for (x = 0; x < 20; x++)
//        {
//            basura[x] = GameObject.Find("Basura" + (x + 1).ToString());
//            animales[x] = GameObject.Find(nombres[x]);
//            //animales[x].SetActive(false);
//        }
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (BarraProgreso.act > 0)
//        {
//            x = ((BarraProgreso.act / 5));
//            for (i = x; i == 19; i++)
//            {
//                animales[x].SetActive(false);
//            }
//            //x=(GameObject.Find("Button_menos").GetComponent<menosanimales>().countmenos);
//            //print("contador menos: " + x);
//        }

//        //if (Slider.GetComponent<BarraProgreso>().act > 0)
//        //{
//        //    x = ((Slider.GetComponent<BarraProgreso>().act / 5));
//        //}
        
//        //animales[0].SetActive(true);
//        //animales[19].SetActive(true);
//        //if (count == 20)
//        //{
//        //    count -= 1;
//        //}
//        //if (count == -1)
//        //{
//        //    count += 1;
//        //}
//    }
//    public void aumentaranimales()
//    {
//        if (Slider.GetComponent<BarraProgreso>().act <= 95 && Slider.GetComponent<BarraProgreso>().act>0)
//        {
//            //if (x == 20)
//            //{
//            //    x -= 1;
//            //}
//            //animales[x-1].SetActive(true);
//            //basura[x-1].SetActive(false);
//            Slider.GetComponent<BarraProgreso>().act += 5;
//            count+=1;
//            Debug.Log("contador: " + count);
//            //x += 1;
//        }

//    }
    
//    public void disminuiranimales()
//    {
//        if (Slider.GetComponent<BarraProgreso>().act >= 5 && Slider.GetComponent<BarraProgreso>().act > 0)
//        {
//            //if (x == 20)
//            //{
//            //    x -= 1;
//            //}
//            animales[x-1].SetActive(false);
//            basura[x-1].SetActive(true);
//            Slider.GetComponent<BarraProgreso>().act -= 5;
//            count -= 1;
//            Debug.Log("contador: " + count);
//        }
//    }
//}
