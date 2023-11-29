using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStation : MonoBehaviour
{
    [SerializeField, Tooltip("the camera that this connects to")]private Camera attachedCamera;
    [SerializeField, Tooltip("the canvas that this connects to")]private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Activate(){
        attachedCamera.enabled = true;
        Camera.main.enabled = false;
        canvas.SetActive(true);
    }

    public void OnMouseDown(){
        Activate();
    }
}
