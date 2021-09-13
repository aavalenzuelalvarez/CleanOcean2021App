using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refrectionfollow : MonoBehaviour
{
    private GameObject boatPrefab;
    // Start is called before the first frame update
    void Start()
    {
        boatPrefab = GameObject.Find("BoatPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(boatPrefab.GetComponent<Transform>().position.x - 80, -14f, boatPrefab.GetComponent<Transform>().position.z - 35);
    }
}

