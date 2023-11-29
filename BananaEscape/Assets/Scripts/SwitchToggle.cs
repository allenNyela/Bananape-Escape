using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField, Tooltip("A list of all connected toggleable objects")]private List<SwitchToggleObject> toggleObjects = new List<SwitchToggleObject>();
    private List<LineRenderer> wires = new List<LineRenderer>();
    [SerializeField, Tooltip("wire prefab")]private GameObject wirePrefab;
    [SerializeField, Tooltip("the color attributed to this toggle")]private Color circuitColor;
    [SerializeField, Tooltip("the z depth for wires")]private float wireZDepth = -2;
    // [SerializeField, Tooltip("the off sprite")]private Sprite offSprite;
    // [SerializeField, Tooltip("the on sprite")]private Sprite onSprite;
    //private bool 
    // Start is called before the first frame update
    public void Toggle()
    {
        foreach (SwitchToggleObject obj in toggleObjects)
        {
            obj.Toggle();
        }
    }

    public void EnableWires(bool enabled){
        foreach(LineRenderer wire in wires){
            wire.enabled = enabled;
        }
    }

    private void CreateWires() {
        foreach(SwitchToggleObject toggleObj in toggleObjects){
            GameObject wireObj = Instantiate(wirePrefab, transform);
            LineRenderer renderer = wireObj.GetComponent<LineRenderer>();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(transform.position);
            //renderer.SetPositions(new Vector3[] { new Vector3(worldPos.x, worldPos.y, toggleObj.transform.position.z), toggleObj.transform.position });
            renderer.SetPositions(new Vector3[] { new Vector3(worldPos.x, worldPos.y, wireZDepth), new Vector3(toggleObj.getAttachPos().x, toggleObj.getAttachPos().y, wireZDepth) });
            renderer.startColor = circuitColor;
            renderer.endColor = circuitColor;
            wires.Add(renderer);
        }
    }

    private void Start() {
        CreateWires();
    }
}
