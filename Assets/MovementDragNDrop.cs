using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDragNDrop : MonoBehaviour
{
    public float speed=50;
    private int x=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (GetComponent<Transform>().position.x > 172)
        //{
        //    transform.RotateAround(transform.position, transform.up, 180f);
        //    speed *= -1;
        //    ;
        //}
        //if (GetComponent<Transform>().position.x > 172)
        //{
        //    GetComponent<Transform>().rotation = new Quaternion (0, (GetComponent<Transform>().rotation.y + 180), 0, 0);
        //    speed *= -1;
        //    ;
        //}
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (GetComponent<Transform>().position.x > 172 && x==0)
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            //speed *= -1;
            x += 1;
        }
        else if (GetComponent<Transform>().position.x < -180 && x == 1)
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            //speed *= -1;
            x -= 1;
        }
    }
}
