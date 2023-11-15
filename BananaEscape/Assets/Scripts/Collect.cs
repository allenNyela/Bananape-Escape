using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public GameObject inventory;
    //public InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            gameObject.GetComponent<InventoryManager>().SetKey(true);
            inventory.SetActive(true);
            Destroy(gameObject);
        }
    }
}
