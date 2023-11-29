using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggleCamera : SwitchToggleObject
{
    [SerializeField, Tooltip("the collider object that appears when the camera is turned on")]private GameObject cameraVision;
    [SerializeField, Tooltip("the origin for camera raycasting (for horizontal checking)")]private Transform RaycastOriginPoint;
    [SerializeField, Tooltip("the first camera raycast point (for horizontal checking)")]private Transform horiRaycastPoint;
    [SerializeField, Tooltip("the second camera raycast point (for vertical checking)")]private Transform vertRaycastPoint;
    [SerializeField, Tooltip("the horizontal sprite mask")]private Transform horiSpriteMask;
    [SerializeField, Tooltip("the vertical sprite mask")]private Transform vertSpriteMask;
    [SerializeField, Tooltip("the layermask for the obstacles taht can block camera view")]private LayerMask obstacleLayer;
    // Start is called before the first frame update
    public override void Toggle(){
        base.Toggle();
        cameraVision.SetActive(activated);
        Debug.Log("huh");
    }

    void Start()
    {
        cameraVision.SetActive(activated);
        PolygonCollider2D polyCol = cameraVision.GetComponent<PolygonCollider2D>();
        if(!RaycastOriginPoint){
            GameObject newGO = new GameObject("Raycast Origin");
            RaycastOriginPoint = newGO.transform;
            RaycastOriginPoint.parent = cameraVision.transform;
            RaycastOriginPoint.localPosition = new Vector3(polyCol.points[0].x, polyCol.points[0].y, transform.position.z);
           
        }
        if(!horiRaycastPoint){
            GameObject newGO = new GameObject("Raycast Horizontal Point");
            horiRaycastPoint = newGO.transform;
            horiRaycastPoint.parent = cameraVision.transform;
            horiRaycastPoint.localPosition = new Vector3(polyCol.points[1].x, polyCol.points[1].y, transform.position.z);
            
        }
        if(!vertRaycastPoint){
            GameObject newGO = new GameObject("Raycast Vertical Point");
            vertRaycastPoint = newGO.transform;
            vertRaycastPoint.parent = cameraVision.transform;
            vertRaycastPoint.localPosition = new Vector3(polyCol.points[2].x, polyCol.points[2].y, transform.position.z);
            
        }
        horiSpriteMask.transform.rotation = Quaternion.identity;
        horiSpriteMask.position = new Vector3(vertSpriteMask.position.x, (RaycastOriginPoint.position.y + vertRaycastPoint.position.y) / 2, vertSpriteMask.position.z);
        horiSpriteMask.localScale = new Vector3(vertSpriteMask.lossyScale.x, Mathf.Abs(RaycastOriginPoint.position.y - vertRaycastPoint.position.y), vertSpriteMask.lossyScale.z);
        vertSpriteMask.rotation = Quaternion.identity;
        vertSpriteMask.position = new Vector3((RaycastOriginPoint.position.x + horiRaycastPoint.position.x) / 2, horiSpriteMask.position.y, horiSpriteMask.position.z);
        vertSpriteMask.localScale = new Vector3(Mathf.Abs(RaycastOriginPoint.position.x - horiRaycastPoint.position.x), horiSpriteMask.lossyScale.y, horiSpriteMask.lossyScale.z);
    }


    private void FixedUpdate() {
        CheckRaycasts();
    }

    public void CheckRaycasts(){
        Debug.Log("checking raycasts");
        
        RaycastHit2D hit2D = Physics2D.Linecast(RaycastOriginPoint.position, horiRaycastPoint.position, obstacleLayer);
        if(hit2D){
            //if(hit2D.point.x > horiRaycastPoint.position.x){
                horiSpriteMask.position = new Vector3((hit2D.point.x + horiRaycastPoint.position.x) / 2, horiSpriteMask.position.y, horiSpriteMask.position.z);
                horiSpriteMask.localScale = new Vector3(Mathf.Abs(hit2D.point.x - horiRaycastPoint.position.x), horiSpriteMask.lossyScale.y, horiSpriteMask.lossyScale.z);
            //}
        }
        else{
            horiSpriteMask.position = new Vector3(horiRaycastPoint.position.x, horiSpriteMask.position.y, horiSpriteMask.position.z);
            horiSpriteMask.localScale = new Vector3(0, horiSpriteMask.lossyScale.y, horiSpriteMask.lossyScale.z);
        }

        hit2D = Physics2D.Linecast(RaycastOriginPoint.position, vertRaycastPoint.position, obstacleLayer);
        if(hit2D){
            //if(hit2D.point.y > vertRaycastPoint.position.y){
                vertSpriteMask.position = new Vector3(vertSpriteMask.position.x, (hit2D.point.y + vertRaycastPoint.position.y) / 2, vertSpriteMask.position.z);
                vertSpriteMask.localScale = new Vector3(vertSpriteMask.lossyScale.x, Mathf.Abs(hit2D.point.y - vertRaycastPoint.position.y), vertSpriteMask.lossyScale.z);
            //}
        }
        else{
            vertSpriteMask.position = new Vector3(vertSpriteMask.position.x, vertRaycastPoint.position.y, vertSpriteMask.position.z);
            vertSpriteMask.localScale = new Vector3(vertSpriteMask.lossyScale.x, 0, vertSpriteMask.lossyScale.z);
        }
    }
}
