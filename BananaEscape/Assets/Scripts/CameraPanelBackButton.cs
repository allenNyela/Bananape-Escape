using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanelBackButton : MonoBehaviour
{
    
    public void ResetCamera(){
        CameraReset.Instance.ResetCamera();
        GameManager.Instance.Pause(false);
    }
}
