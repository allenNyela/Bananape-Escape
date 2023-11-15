using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField, Tooltip("A list of all connected toggleable objects")]private List<SwitchToggleObject> toggleObjects = new List<SwitchToggleObject>();
    // Start is called before the first frame update
    public void Toggle()
    {
        foreach (SwitchToggleObject obj in toggleObjects)
        {
            obj.Toggle();
        }
    }
}
