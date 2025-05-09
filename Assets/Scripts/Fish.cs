﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish: MonoBehaviour {
    public float speed = 10.0f;
    private Rigidbody rb;
    private Vector2 screenBounds;


    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update () {
        if(transform.position.y < screenBounds.y){
            Destroy(this.gameObject);
        }
    }
}