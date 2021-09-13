using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaRenderer : MonoBehaviour{
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform startPosition;
    private float line_Width = 1.5f;

    void Awake(){
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = line_Width;
        lineRenderer.enabled = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RenderLine(Vector3 endPosition, bool enableRenderer){
        if(enableRenderer){
            if(!lineRenderer.enabled){ lineRenderer.enabled = true; }
            lineRenderer.positionCount = 2;

        } else {
            lineRenderer.positionCount = 0;
            if(lineRenderer.enabled){ lineRenderer.enabled = false; }
        }
        if(lineRenderer.enabled){
            Vector3 temp = startPosition.position;
            temp.z = 89.8f;
            temp.x = 2.34f;
            temp.y = 24.08f;
            startPosition.position = temp;
            temp = endPosition;
            temp.z = 89.8f;
            endPosition = temp;
            lineRenderer.SetPosition(0, startPosition.position);
            lineRenderer.SetPosition(1, endPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
