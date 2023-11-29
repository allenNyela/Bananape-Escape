using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image m_Icon;

    [SerializeField]
    private GameObject m_Obj;

    public void Set(InventoryItem item) {
        Debug.Log($"Item: {item.data.displayName}, Stack Size: {item.stackSize}, Image Reference: {item.data.icon}");
        if (m_Icon != null) {
            m_Icon.sprite = item.data.icon;
        }

        if (item.stackSize < 1) {
            if (m_Obj != null) {
                m_Obj.SetActive(false);
            }
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
