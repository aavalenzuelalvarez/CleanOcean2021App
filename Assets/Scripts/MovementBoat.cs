using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoat : MonoBehaviour
{
    public float speed = 50f;
    private int positionx, positiony;
    private float positionz;
    // Start is called before the first frame update
    void Start()
    {
        positionx = -222;
        positionz = 57;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime*20);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.position = new Vector3(positionx, 0, positionz);
        positionz += 0.1f;


    }
}
