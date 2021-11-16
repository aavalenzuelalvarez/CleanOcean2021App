using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNaves : MonoBehaviour
{
    /*
    public void Start(){
        StartCoroutine(Movimiento());
    }
    public IEnumerator Movimiento(){
        for(float x = 0; x<500 ; x=x+0.1f){
            for(float y = -500; y<500 ; y=y+0.1f){
                yield return new WaitForSeconds(0.1f);
                transform.localPosition = new Vector3(x, y, transform.localPosition.z);
            }
        }
    }
*/
/* Danndx 2021 (youtube.com/danndx)
From video: youtu.be/u5ieakSbXjA
thanks - delete me! :) */
    public MovimientoNavesSpawn ship_spawner;
    public GameObject game_area;

    public float speed;

    void Update()
    {
        Move();
    }

    void Move()
    {
        /** Move this ship forward per frame, if it gets too far from the game area, destroy it **/

        transform.position += transform.up * (Time.deltaTime * speed);

        float distance = Vector3.Distance(transform.position, game_area.transform.position);
        if(distance > ship_spawner.death_circle_radius)
        {
            RemoveShip();
        }
    }

    void RemoveShip()
    {
        /** Update the total ship count and then destroy this individual ship. **/

        Destroy(gameObject);
        ship_spawner.ship_count -= 1;
    }
}