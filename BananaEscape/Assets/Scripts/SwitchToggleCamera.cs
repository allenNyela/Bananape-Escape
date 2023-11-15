using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggleCamera : SwitchToggleObject
{
    [SerializeField, Tooltip("the collider object that appears when the camera is turned on")]private GameObject cameraVision;
    // Start is called before the first frame update
    public override void Toggle(){
        base.Toggle();
        cameraVision.SetActive(activated);
    }

    void Start()
    {
        cameraVision.SetActive(activated);
    }
}
