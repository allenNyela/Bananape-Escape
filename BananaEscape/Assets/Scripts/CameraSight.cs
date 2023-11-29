using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSight : MonoBehaviour
{
    [SerializeField, Tooltip("the tag for the player")]private string playerTag = "Player";
    [SerializeField, Tooltip("the origin point for raycasting")]private Transform raycastOrigin;
    [SerializeField, Tooltip("the layermask for the obstacles taht can block camera view")]private LayerMask obstacleLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("collision");
        if(col.gameObject.tag == playerTag){
            Debug.Log("player collision");
            RaycastHit2D hit2D = Physics2D.Linecast(raycastOrigin.position, col.gameObject.transform.position, obstacleLayer);
            if(!hit2D){
                Debug.Log("player seen");
                SoundAlarm();
            }
        }
    }

    public void SoundAlarm(){
        GameManager.Instance.GameOver();
    }
}
