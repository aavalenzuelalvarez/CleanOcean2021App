using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    // gravity constant
    public float g = 9.8f;
    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.up);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.down);

    }
    //void FixedUpdate()
    //{
    //    // normalize axis
    //    var gravity = new Vector3(
    //        Input.acceleration.x,
    //        Input.acceleration.z,
    //        Input.acceleration.y
    //    ) * g*-1;

    //    GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
    //}

}