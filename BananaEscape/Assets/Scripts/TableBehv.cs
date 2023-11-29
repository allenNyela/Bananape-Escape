using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBehv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            gameObject.GetComponent<Table>().SetHidden(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            gameObject.GetComponent<Table>().SetHidden(false);
        }
    }
}
