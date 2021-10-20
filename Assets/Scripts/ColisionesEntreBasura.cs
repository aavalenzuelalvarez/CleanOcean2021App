using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesEntreBasura : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col){
        if(col.collider.tag == "Lata" | col.collider.tag == "Papel" | col.collider.tag == "Vidrio" ){
            Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
