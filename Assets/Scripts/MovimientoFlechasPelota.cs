using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFlechasPelota : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 30;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        var gravity = new Vector3(-joystick.Horizontal, 0, -joystick.Vertical)* velocidad;
        rb.AddForce(gravity,ForceMode.Acceleration);
    }
}
