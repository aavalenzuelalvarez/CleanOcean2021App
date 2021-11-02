using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrash : MonoBehaviour
{
    private int x;
    private float positiony;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.gameObject.GetComponent<Transform>().position.z < GameObject.Find("BoatPrefab").GetComponent<Transform>().position.z-5)
        {
            x = Random.Range(-285,-163);
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
            if (GetComponent<Transform>().position.z +200 < GameObject.Find("Isla actLancha").GetComponent<Transform>().position.z - 10)
            {
                transform.position = new Vector3(x, positiony, GetComponent<Transform>().position.z + 150);
            }
            else
            {
                Destroy(this.gameObject);
            }
                
        }
        
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
