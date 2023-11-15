using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static bool HasKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetKey(bool hasKey)
    {
        HasKey = hasKey;
    }

    public bool GetKey()
    {
        return HasKey;
    }
}
