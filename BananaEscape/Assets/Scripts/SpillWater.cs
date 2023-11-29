using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillWater : MonoBehaviour
{
    public LabInteractionController controller;
    public void OnSpillWater() {
        controller.BeakerSpill();
    }
}
