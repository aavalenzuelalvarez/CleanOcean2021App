using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistencia : MonoBehaviour
{
    private static GameObject instance;
    void Awake(){
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
