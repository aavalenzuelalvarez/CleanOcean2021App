using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyroscope : MonoBehaviour
{
    //para gyro
    private bool gyroEnabled;
    private Gyroscope gyro;
    public GameObject cameraContainer;
    private Quaternion rot;
    public float x, y, w, z;

    //para acelrometro
    public Vector2 rotAngle;
    public float speedrot = 1;
    Vector3 angle;
    Vector3 tempAngle;

    // Start is called before the first frame update
    void Start()
    {
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        cameraContainer.transform.rotation =  Quaternion.Euler(0, 0, 0);
        //print("start" + cameraContainer.transform.rotation);
        gyroEnabled = EnableGyro();
    }

    // Update is called once per frame
    bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            UnityEngine.Gyroscope gyro = Input.gyro;
            gyro.enabled = true;
            //Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
            //this.transform.localRotation = cameraRotation;
            
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            //print("enable gyro" + cameraContainer.transform.rotation);
            rot = new Quaternion(0,0,1,0);
            //rot = new Quaternion(0.7f, 0.0f, -0.1f, -0.7f);
            return true;
        }
        return false;

    }
    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = Input.gyro.attitude * rot;
            //rot = new Quaternion(x, y, w, z);
            //print("update " + cameraContainer.transform.rotation);

        }
        else
        {
            //acelerometro
            angle.x = (Input.acceleration.y * rotAngle.y);
            angle.y = (Input.acceleration.x * rotAngle.x);
            //print("angulox: " + angle.x);
            //print("anguloy: " + angle.y);

            tempAngle = Vector3.Slerp(tempAngle, angle, Time.deltaTime * speedrot);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(tempAngle), Time.deltaTime * speedrot);
            //print("rotacion: " + transform.rotation);
        }
        //cameraContainer.transform.rotation = Quaternion.Euler(posx, posy, posz);
    }
}
