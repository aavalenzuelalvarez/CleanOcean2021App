using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardLaberinto : MonoBehaviour
{
    private Camera theCam;
    public bool useStaticBillboard;
    
    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            transform.LookAt(theCam.transform);
        }else{
            transform.rotation = theCam.transform.rotation;
        }
        
        if(this.gameObject.name == "Botella De Vidrio"){
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 50);
        }else{
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        
    }
}
