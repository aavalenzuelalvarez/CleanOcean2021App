using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GanchoMovimientoOnlineDois : MonoBehaviour
{
    private PhotonView photonView;
    public float min_Z = -55f, max_Z = 55f;
    public float rotate_Speed = 5f;

    private float rotate_Angle;
    private bool rotate_Right;
    public static bool canRotateDois;

    public float move_Speed = 3f;
    private float initial_Move_Speed;

    public float min_Y = -6.7f;
    private float initial_Y;

    public static bool moveDownOnlineDois;
    public GameObject GanchoPlayer1;

    // FOR LINE RENDERER
    private CuerdaRenderer ropeRenderer;
    void Awake(){
        ropeRenderer = GetComponent<CuerdaRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initial_Y = transform.position.y;
        Debug.Log("Initial y player 2Dois : " + initial_Y);
        initial_Move_Speed = move_Speed;
        canRotateDois = true;
    }

    // Update is called once per frame
    void Update(){
        ropeRenderer.RenderLine(transform.position, true);
        photonView = GetComponent<PhotonView>();
        if (GanchoPlayer1.transform.position.y < initial_Y)
        {
            GanchoMovimientoOnline.canRotate = false;
        }
        MoveRopeDois();
        Rotate();
    }
    
    void Rotate(){
        if (!canRotateDois)
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
    public void GetInputButton(){
        canRotateDois = false;
        if(!canRotateDois){
            canRotateDois = false;
            moveDownOnlineDois = true;
        }
        
        // if(Input.GetButton("BajarGancho")){
        //     if(canRotateDois){
        //         canRotateDois = false;
        //         moveDownOnlineDois = true;
        //     }
        // }
    }
    void MoveRopeDois(){
        if (canRotateDois)
            return;
        if (!canRotateDois){
            Vector3 temp = transform.position;
            if(moveDownOnlineDois){
                temp -= transform.up * Time.deltaTime * move_Speed;
            }else{
                temp += transform.up * Time.deltaTime * move_Speed; 
            }
            transform.position = temp;
            if(temp.y <= min_Y){
                Debug.Log("entra al if(temp.y <= min_Y)");
                moveDownOnlineDois = false;
            }
            if(temp.y >= initial_Y){
                canRotateDois = true;
                //deactivate line renderer
                ropeRenderer.RenderLine(temp, false);
                //reset move speed
                move_Speed = initial_Move_Speed;
            }
            
        }
        
    }
}
