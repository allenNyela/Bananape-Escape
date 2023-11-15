using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggleObject : MonoBehaviour
{
    [SerializeField, Tooltip("whether this object is active or not")]protected bool activated = false;
    
    public virtual void Toggle(){
        activated = !activated;
    }
}
