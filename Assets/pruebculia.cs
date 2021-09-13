using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebculia: MonoBehaviour
{

    [SerializeField]
    private Transform Ejemplo;
    private Vector2 initialPosition;

    private float deltaX, deltaY;

    public bool locked = false;


    // Use this for initialization
    void Start()
    {

        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }

                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - Ejemplo.position.x) <= 10.0f &&
                        Mathf.Abs(transform.position.y - Ejemplo.position.y) <= 10.0f)
                    {
                        transform.position = new Vector2(Ejemplo.position.x, Ejemplo.position.y);
                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);

                    }
                    break;
            }


        }
    }
}