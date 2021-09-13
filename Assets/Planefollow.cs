using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planefollow : MonoBehaviour
{
    private GameObject boatPrefab;
    // Start is called before the first frame update
    void Start()
    {
        boatPrefab = GameObject.Find("BoatPrefab");
        //print(boatPrefab.GetComponent<Transform>().position.x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(boatPrefab.GetComponent<Transform>().position.x, -0.54f, boatPrefab.GetComponent<Transform>().position.z);
    }
}
