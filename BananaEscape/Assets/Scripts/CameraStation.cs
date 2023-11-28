using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStation : MonoBehaviour
{
    [SerializeField, Tooltip("the camera that this connects to")]private Camera attachedCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Activate(){
        attachedCamera.enabled = true;
        Camera.main.enabled = false;
    }
}
