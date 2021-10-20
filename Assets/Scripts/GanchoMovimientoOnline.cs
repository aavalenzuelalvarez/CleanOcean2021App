using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GanchoMovimientoOnline : MonoBehaviour
{
    private PhotonView photonView;
    public float min_Z = -55f, max_Z = 55f;
    public float rotate_Speed = 5f;

    private float rotate_Angle;
    private bool rotate_Right;
    public static bool canRotate;

    public float move_Speed = 3f;
    private float initial_Move_Speed;

    public float min_Y = -6.7f;
    private float initial_Y;

    public static bool moveDownOnline;
    public GameObject GanchoPlayer2;

    // FOR LINE RENDERER
    private CuerdaRenderer ropeRenderer;
    void Awake(){
        ropeRenderer = GetComponent<CuerdaRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initial_Y = transform.position.y;
        Debug.Log("Initial y player 1 : " + initial_Y);
        initial_Move_Speed = move_Speed;
        canRotate = true;
    }

    // Update is called once per frame
    void Update(){
        ropeRenderer.RenderLine(transform.position, true);
        photonView = GetComponent<PhotonView>();
        if (GanchoPlayer2.transform.position.y < initial_Y)
        {
            GanchoMovimientoOnlineDois.canRotateDois = false;
        }
        MoveRope();
        Rotate();
    }
    
    void Rotate(){
        if (!canRotate)
            return;
        if (rotate_Right){
            rotate_Angle += rotate_Speed * Time.deltaTime;
        }else{
            rotate_Angle -= rotate_Speed * Time.deltaTime;
        }
        transform.rotation = Quaternion.AngleAxis(rotate_Angle, Vector3.forward);
        if(rotate_Angle >= max_Z){
            rotate_Right = false;
        }else if(rotate_Angle <= min_Z){
            rotate_Right = true;
        }
    }
    public void GetInput(){
        canRotate = false;
        if(!canRotate){
            canRotate = false;
            moveDownOnline = true;
        }
        
        // if(Input.GetButton("BajarGancho")){
        //     if(canRotate){
        //         canRotate = false;
        //         moveDownOnline = true;
        //     }
        // }
    }
    void MoveRope(){
        if (canRotate)
            return;
        if (!canRotate){
            Vector3 temp = transform.position;
            if(moveDownOnline){
                temp -= transform.up * Time.deltaTime * move_Speed;
            }else{
                temp += transform.up * Time.deltaTime * move_Speed; 
            }
            transform.position = temp;
            if(temp.y <= min_Y){
                Debug.Log("entra al if(temp.y <= min_Y)");
                moveDownOnline = false;
            }
            if(temp.y >= initial_Y){
                canRotate = true;
                //deactivate line renderer
                ropeRenderer.RenderLine(temp, false);
                //reset move speed
                move_Speed = initial_Move_Speed;
            }
            
        }
        
    }
}
