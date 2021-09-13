using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyFish : MonoBehaviour
{
    private Vector2 screenBounds;


    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 60 || transform.position.x <-60)
        {
           // Destroy(this.gameObject);
        }
    }
}