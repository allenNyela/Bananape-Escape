using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    [SerializeField, Tooltip("the main camera for the game")]private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        ResetCamera();
    }

    void ResetCamera(){
        if(mainCamera != Camera.main){
            Camera.main.enabled = false;
        }
        mainCamera.enabled = true;
    }
}
