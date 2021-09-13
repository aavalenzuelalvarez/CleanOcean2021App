 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesFollow : MonoBehaviour
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
        transform.position = new Vector3(boatPrefab.GetComponent<Transform>().position.x-120, -0.44f, boatPrefab.GetComponent<Transform>().position.z-10);
    }
}
