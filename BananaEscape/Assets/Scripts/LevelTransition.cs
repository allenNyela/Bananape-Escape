using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField, Tooltip("the object that will cover the camera")]private Transform blocker;
    [SerializeField, Tooltip("the original starting position in front of the camera")]private Transform startPos;
    [SerializeField, Tooltip("the position that the object will move to when sweeping off")]private Transform sweepOffPos;
    [SerializeField, Tooltip("the position that the object will move from when sweeping in")]private Transform sweepInPos;
    [SerializeField, Tooltip("the speed at which it will sweep")]private float sweepSpeed;
    private Transform goalPos;
    private bool sliding = false;
    private bool leavingScene = false;
    private string sceneToChangeTo = "";

    private static LevelTransition _instance;
    public static LevelTransition Instance
    {
        get{
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelTransition>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<LevelTransition>();
                    Debug.Log("Generating new LevelTransition");
                }
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SweepOff();
    }

    public void SweepOff(){
        blocker.position = startPos.position;
        goalPos = sweepOffPos;
        sliding = true;
        Debug.Log("Starting sweep off: start pos " + blocker.position + ", and goal pos " + goalPos.position);
    }

    public void SweepIn(string sceneToTransitionTo){
        blocker.position = sweepInPos.position;
        goalPos = startPos;
        sliding = true;
        leavingScene = true;
        sceneToChangeTo = sceneToTransitionTo;
    }

    void ResetLevel(){
        SweepIn(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate(){
        if(sliding){
            blocker.position = Vector3.MoveTowards(blocker.position, goalPos.position, sweepSpeed * Time.fixedDeltaTime);
            if(Vector3.Distance(blocker.position, goalPos.position) < .0001f){
                sliding = false;
                if(leavingScene){
                    SceneManager.LoadScene(sceneToChangeTo);
                }
            }
        }
    }

    public void ConnectToCamera(Transform cameraTransform){
        transform.parent = cameraTransform;
    }
}
