using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButtonsRecomp : MonoBehaviour
{
    public GameObject[] Botones;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        for (i=0; i <= Botones.Length-1; i++)
        {
            Botones[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
