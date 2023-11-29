using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    static bool Hidden = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetHidden()
    {
        return Hidden;
    }

    public void SetHidden(bool hidden)
    {
        Hidden = hidden;
    }
}
