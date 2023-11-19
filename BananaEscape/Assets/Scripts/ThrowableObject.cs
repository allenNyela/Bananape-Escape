using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        PickupManager.Instance.GiveToPlayer(gameObject);
    }
}
