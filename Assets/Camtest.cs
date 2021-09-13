using UnityEngine;
using System.Collections;

public class Camtest : MonoBehaviour
{

    public Vector2 rotAngle;
    public float speedrot=1;
    Vector3 angle;
    Vector3 tempAngle;

    private void Start()
    {
        //rotAngle.x += 90;
        //rotAngle.x *= -1;
        //rotAngle.y *= -1;
    }
    // Update is called once per frame
    void Update()
    {
        angle.x = (Input.acceleration.y * rotAngle.y);
        angle.y = (Input.acceleration.x * rotAngle.x);
        print ("angulox: " + angle.x);
        print ("anguloy: " + angle.y);

        tempAngle = Vector3.Slerp(tempAngle, angle, Time.deltaTime * speedrot);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(tempAngle), Time.deltaTime * speedrot);
        print("rotacion: "+transform.rotation);
    }
}