using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggleObject : MonoBehaviour
{
    [SerializeField, Tooltip("whether this object is active or not")]protected bool activated = false;
    [SerializeField, Tooltip("the attach point for the wires on this object")]protected Transform attachPoint;
    
    public virtual void Toggle(){
        activated = !activated;
    }

    public Vector3 getAttachPos(){
        return attachPoint.position;
    }
}
