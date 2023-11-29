using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject m_SlotPrefab;

    public GameObject inventoryObject;

    private InventorySystem inventorySystem;

    // Start is called before the first frame update
    void Start()
    {
        inventorySystem = inventoryObject.GetComponent<InventorySystem>();
        inventorySystem.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void OnUpdateInventory() {
        foreach (Transform t in transform) {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    public void DrawInventory() {
        foreach(InventoryItem item in inventorySystem.inventory) {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item) {
        GameObject obj = Instantiate(m_SlotPrefab);
        obj.transform.SetParent(transform, false);
        ItemSlot slot = obj.GetComponent<ItemSlot>();
        slot.Set(item);
    }
}
