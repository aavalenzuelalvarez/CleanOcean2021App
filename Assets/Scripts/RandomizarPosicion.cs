using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizarPosicion : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-50,50);
        y = Random.Range(-34, 7);
        z = 90;
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
