using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movewhencollide : MonoBehaviour
{
    public int x, posy;
    private float positiony;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        x = Random.Range(-285, -163);

        if (gameObject.name == "BasuraPrefab")
        {
            positiony = -0.63f;
        }
        else if (gameObject.name == "RuedaPrefab")
        {
            positiony = -0.3f;
        }
        else if (gameObject.name == "BasuraPrefab")
        {
            positiony = -0.4f;
        }
        this.transform.position = new Vector3(x, positiony, GetComponent<Transform>().position.z + 160);
    }
}
