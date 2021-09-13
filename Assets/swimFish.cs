using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimFish : MonoBehaviour
{
    //public GameObject rotatedObject;
    public float speed;
    public float turnspeed = 10f;
    //bool rotating = false;
    private int colis = 0;
    private float ejey;
    private float eulerangle, rotationy, rotationx, angley, anglex;
    private int eulerauxl, eulerauxr, randomrotation;
    private Vector3 direction = new Vector3(0,0,-1);
    public float smoothTime = 5.0f; //rotate over 5 seconds

    private void Start()
    {
        //var direction = new Vector3(0, 0, 1);
        ejey = this.GetComponent<Transform>().rotation.y;
    }
    void Update()
    {
        if (this.name == "Mantarraya")
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if (this.name == "Tortuga")
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (this.name == "Tiburon blanco" || this.name == "Salmon rosa" || this.name == "Salmon")
        {
            transform.Translate(0,0,1 * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }
        if (colis == 0)
        {
            transform.eulerAngles = new Vector3(0, ejey, 0);
        }
        
        //print("derecha" + eulerauxr);
        //print("izquierda" + eulerauxl);
    }
    void OnCollisionEnter(Collision col)
    {
        //print("DEBUGGG");
        if (col.gameObject.tag == "Limit horizontal")
        {
            print("HORIZONTAL");
            transform.RotateAround(transform.position, transform.up, 180f);
            //print("CHOQUÉ pa los laos");
            //print("angley: " + (int)angley);
            //print("eulerangley: " + (int)transform.eulerAngles.y);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * turnspeed);
            //direction.x *= -1;
            //speed = 0;
            ejey += 180;
        }
        else if (col.gameObject.tag == "Limit vertical")
        {
            print("VERTICAL");
            transform.RotateAround(transform.position, transform.right, 180f);
            //print("CHOQUÉ pa arriba");
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(anglex, 0, 0), Time.deltaTime * turnspeed);
            ejey += 180;
        }
    }
}


//void OnCollisionEnter(Collision col)
//{
//    if (col.gameObject.tag == "Limits" && !rotating) // we dont want to call this if the object is already rotating, so we check if it is
//    {
//        //Rotate rotatedObject by 90 degrees on the Y axis
//        rotating = true;
//        float rando = Random.Range(0, 100); // pick a random number between 1 and 100
//        int multiplier = 1;
//        if (rando > 50)
//        {
//            multiplier = -1;
//        }
//        StartCoroutine(RotateOverTime(rotatedObject.transform.localEulerAngles.y, rotatedObject.transform.localEulerAngles.y + (90 * multiplier), smoothTime));
//    }
//}
//IEnumerator RotateOverTime(float currentRotation, float desiredRotation, float overTime)
//{
//    float i = 0.0f;
//    while (i <= 1)
//    {
//        rotatedObject.transform.localEulerAngles = new Vector3(rotatedObject.transform.localEulerAngles.x, Mathf.Lerp(currentRotation, desiredRotation, i), rotatedObject.transform.localEulerAngles.z);
//        i += Time.deltaTime / overTime;
//        yield return null;
//    }
//    yield return new WaitForSeconds(overTime);
//    rotating = false; // no longer rotating
//}


