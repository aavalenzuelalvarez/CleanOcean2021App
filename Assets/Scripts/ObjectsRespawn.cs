using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRespawn : MonoBehaviour
{
    //private float b;
    private int x;
    private GameObject boatPrefab;
    // Start is called before the first frame update
    void Start()
    {
        boatPrefab = GameObject.Find("/BoatPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < boatPrefab.GetComponent<Transform>().position.z-10)
        {
            x = Random.Range(-22, 120);
            
            transform.position = new Vector3(x, 1, boatPrefab.GetComponent<Transform>().position.z + 10);
        }
    }
}
