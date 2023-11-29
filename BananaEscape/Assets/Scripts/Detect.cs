using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public GameObject GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            if (!gameObject.GetComponent<Table>().GetHidden()) {
                this.GetComponent<InventoryManager>().SetKey(false);
                GameOverScreen.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            if (!gameObject.GetComponent<Table>().GetHidden())
            {
                this.GetComponent<InventoryManager>().SetKey(false);
                GameOverScreen.SetActive(true);
            }
        }
    }
}
