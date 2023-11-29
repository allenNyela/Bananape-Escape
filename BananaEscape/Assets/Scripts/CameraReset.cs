using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    [SerializeField, Tooltip("the main camera for the game")]private Camera mainCamera;
    [SerializeField, Tooltip("all of the canvases")]private List<GameObject> Canvases;
    [SerializeField, Tooltip("all of the cameras")]private List<Camera> Cameras;
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
        //mainCamera.enabled = true;
        foreach(GameObject canvas in Canvases){
            canvas.SetActive(false);
        }
        foreach(Camera camera in Cameras){
            camera.enabled = false;
        }
        mainCamera.enabled = true;
        //GameManager.Instance.Pause(false);
    }

    public void HideMainCamera(){
        mainCamera.enabled = false;
    }
}
