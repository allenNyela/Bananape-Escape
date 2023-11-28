using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    [SerializeField, Tooltip("the main camera for the game")]private Camera mainCamera;
    private static CameraReset _instance;
    public static CameraReset Instance
    {
        get{
            if (_instance == null)
            {
                _instance = FindObjectOfType<CameraReset>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<CameraReset>();
                    Debug.Log("Generating new CameraReset");
                }
            }
            return _instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetCamera();
    }

    public void ResetCamera(){
        if(mainCamera != Camera.main){
            Camera.main.enabled = false;
        }
        mainCamera.enabled = true;
    }
}
