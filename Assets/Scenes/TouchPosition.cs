using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchPosition : MonoBehaviour
{
    //public Text m_Text;
    TouchPhase touchPhase = TouchPhase.Ended;

    void Update()
    {
    //     //if (Input.touchCount > 0)
    //     //{
    //     //    Touch touch = Input.GetTouch(0);
    //     //    //Update the Text on the screen depending on current position of the touch each frame
    //     //    print("Touch Position : " + touch.position);
    //     //}
    //     if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
    //     {
    //         Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //         RaycastHit hit;
    //         Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
    //         if (Physics.Raycast(ray, out hit))
    //         {
    //             Debug.Log(hit.transform.name);
    //             if (hit.collider != null)
    //             {

    //                 GameObject touchedObject = hit.transform.gameObject;

    //                 Debug.Log("Touched " + touchedObject.transform.name);
    //             }
    //         }
    //     }
    // }
    }
}