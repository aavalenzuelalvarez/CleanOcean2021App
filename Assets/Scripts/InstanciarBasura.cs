using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarBasura : MonoBehaviour
{
    public GameObject Trash1,boat;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(generateTrash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnTrash()
    {
        GameObject a = Instantiate(Trash1) as GameObject;
        boat = GameObject.Find("BoatPrefab");
        a.transform.position = new Vector3(boat.GetComponent<Transform>().position.x, -100, -362);
    }
    IEnumerator generateTrash()
    {
        
        //while (count <= cantpeces)
        //{
        yield return new WaitForSeconds(1f);
            //var aux = new float [1];
            //aux[0] = 2;
            //GameObject.Find("Respuesta1").GetComponentInChildren<Text>().text = (aux[0]+1).ToString();
            spawnTrash();

        // }
    }
}
