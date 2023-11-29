using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryItem {
    public LabInventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(LabInventoryItemData source) {
        data = source;
        AddToStack();
    }

    public void AddToStack() {
        stackSize++;
    }

    public void RemoveFromStack() {
        stackSize--;
    }
}

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance { get; private set; }
    private Dictionary<LabInventoryItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory {get; private set;}

    public UnityAction onInventoryChangedEvent;

    void Awake()
    {
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<LabInventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(LabInventoryItemData item) {
        if(itemDictionary.TryGetValue(item, out InventoryItem value)) {
            return value;
        }
        else {
            return null;
        }
    }

    public void Add(LabInventoryItemData item) {
        if(itemDictionary.TryGetValue(item, out InventoryItem value)) {
            value.AddToStack();
        }
        else {
            InventoryItem newItem = new InventoryItem(item);
            inventory.Add(newItem);
            itemDictionary.Add(item, newItem);
        }
        
        onInventoryChangedEvent.Invoke();
    }

    public void Remove(LabInventoryItemData item) {
        if(itemDictionary.TryGetValue(item, out InventoryItem value)) {
            value.RemoveFromStack();

            if(value.stackSize == 0) {
                inventory.Remove(value);
                itemDictionary.Remove(item);
            }
            onInventoryChangedEvent.Invoke();
        }
    }

    private void LogInventory()
    {
        Debug.Log("Inventory Contents:");
        foreach (var item in inventory)
        {
            Debug.Log($"Item: {item.data.displayName}, Stack Size: {item.stackSize}, Image Reference: {item.data.icon}");
        }
    }

}
