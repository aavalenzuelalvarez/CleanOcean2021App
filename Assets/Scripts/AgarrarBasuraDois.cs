using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarBasuraDois : MonoBehaviour
{
    private FixedJoint test;
    // Start is called before the first frame update
    void Start()
    {
        print("a");
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 80f);
    }
    private void OnCollisionEnter(Collision col)
    {
        // if ((col.gameObject.name == "BasuraPrefab") || (col.gameObject.name == "RuedaPrefab") || (col.gameObject.name == "BarrilPrefab"))
        // {
        //     GameObject.Find("Conexiones").GetComponent<Conexiones>().Colision(SceneManager.GetActiveScene().name, col.gameObject.name);
        //     x = Random.Range(-285, -163);
        //     if (gameObject.name == "BasuraPrefab")
        //     {
        //         positiony = -0.63f;
        //     }
        //     else if (gameObject.name == "RuedaPrefab")
        //     {
        //         positiony = -0.3f;
        //     }
        //     else if (gameObject.name == "BasuraPrefab")
        //     {
        //         positiony = -0.4f;
        //     }
        //     if (col.transform.position.z + 200 < GameObject.Find("Isla actLancha").GetComponent<Transform>().position.z - 58)
        //     {
        //         col.transform.position = new Vector3(x, positiony, GetComponent<Transform>().position.z + 200);
        //     }
        //     colisiones++;
        //     print(colisiones);
        // }
        FixedJoint fj;
        fj = this.gameObject.AddComponent<FixedJoint>();
        fj.connectedBody = col.collider.GetComponent<Rigidbody>();
        // col.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Debug.Log(col.collider.tag);
        GanchoMovimientoOnlineDois.moveDownOnlineDois = false;
    }
}
