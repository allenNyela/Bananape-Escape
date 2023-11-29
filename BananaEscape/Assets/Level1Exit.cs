using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Level1Manager.Instance.CanWin())
            Level1Manager.Instance.Win();
    }
}
