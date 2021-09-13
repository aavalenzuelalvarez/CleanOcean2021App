using UnityEngine;
using System.Collections;

public class CamaraControl : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    
}
