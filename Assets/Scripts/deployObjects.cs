using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployObjects : MonoBehaviour {
    public GameObject boatPrefab;
    public GameObject[] objectPrefab;
    public float respawnTime = 1.0f;
    //private Vector2 screenBounds;
    private int x,count,trashtype,z;

    // Use this for initialization
    void Start () {
      //  screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(generateTrash());
        z = 270;
        count = 1;
    }
    private void spawnTrash(){
        //b=boatPrefab.GetComponent<Transform>().position.z;
        //Debug.Log(b);
        x = Random.Range(-22, 120);
        trashtype = Random.Range(0, 3);
        GameObject a = Instantiate(objectPrefab[trashtype]) as GameObject;
        a.transform.position = new Vector3(x, 1, z);

        //if (trashtype == 1)
        //{
        //    GameObject Trash = GameObject.Find("BarrilPrefab");
        //    Trash.transform.position = new Vector3(x, 1, z);
        //}

        //if (trashtype == 2)
        //{
        //    GameObject Trash = GameObject.Find("BasuraPrefab");
        //    Trash.transform.position = new Vector3(x, 1, z);
        //}

        //if (trashtype == 3)
        //{
        //    GameObject Trash = GameObject.Find("RuedaPrefab");
        //    Trash.transform.position = new Vector3(x, 1, z);
        //}

        //GameObject a = Instantiate(objectPrefab) as GameObject;
        //a.transform.position = new Vector3(x, 1,z);
        z += 10;
    }

    IEnumerator generateTrash(){
        while(count<=15){
            yield return new WaitForSeconds(respawnTime);
            spawnTrash();
            Debug.Log("contador: " + count);
            count += 1;
        }
    }
    void Update()
    {

    }
}