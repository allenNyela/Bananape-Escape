using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject inventoryObject;

    public GameObject Player;

    private InventorySystem inventorySystem;
    public LabInventoryItemData referenceItem;

    public void Awake() {
        inventorySystem = inventoryObject.GetComponent<InventorySystem>();
    }

    public void OnPickup() {
        if (Vector3.Distance (gameObject.transform.position, Player.transform.position) < 3) {
            inventorySystem.Add(referenceItem);
            Destroy(gameObject);
        }
    }
}
