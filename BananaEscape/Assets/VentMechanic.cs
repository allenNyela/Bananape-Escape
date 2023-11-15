using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentMechanic : MonoBehaviour
{
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<InventoryManager>().GetKey())
        {
            winScreen.SetActive(true);
        }
    }
}
