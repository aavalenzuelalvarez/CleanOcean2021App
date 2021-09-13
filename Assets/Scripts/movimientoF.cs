using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class movimientoF : MonoBehaviour
{

    // gravity constant
    public float g = 9.8f;

    void FixedUpdate()
    {
        // normalize axis
        var gravity = new Vector3(
            -Input.acceleration.x,
             Input.acceleration.z,
            -Input.acceleration.y
        ) * g;

        GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
    }

}