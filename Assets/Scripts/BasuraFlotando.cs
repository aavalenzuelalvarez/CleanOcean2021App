using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraFlotando : MonoBehaviour
{
    private int direction=0;
    public float speed=3f;
    private float maxpositiony, minpositiony;
    // Start is called before the first frame update
    void Start()
    {
        maxpositiony = transform.position.y+30;
        minpositiony = transform.position.y-30;
    }

    // Update is called once per frame
    void Update()
    {

        
       
    }

    private void FixedUpdate()
    {
        if (speed < 5)
        {
            speed += 0.001f; 
        }
        if ((int)(transform.position.y) >= (int)minpositiony && direction==0 ) 
        {
            if ((int)transform.position.y == (int)maxpositiony)
            {
                speed = 3;
                
            }
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        else if ((int)transform.position.y <= (int)maxpositiony)
        {
            direction = 1;

            if ((int) transform.position.y == (int)maxpositiony)
            {
                direction = 0;
                speed = 3;
                
            }
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }


    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Invoke("ChangeDirection", 5f);
    }
}
