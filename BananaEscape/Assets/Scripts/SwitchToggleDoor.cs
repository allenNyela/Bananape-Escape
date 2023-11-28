using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggleDoor : SwitchToggleObject
{
    [SerializeField, Tooltip("the open door object")] private GameObject openDoor;
    [SerializeField, Tooltip("the closed door object")] private GameObject closedDoor;
    // Start is called before the first frame update
    public void SetDoorState()
    {
        openDoor.SetActive(!activated);
        closedDoor.SetActive(activated);
    }

    public override void Toggle()
    {
        base.Toggle();
        SetDoorState();
    }
    
    void Start(){
        SetDoorState();
    }
}
