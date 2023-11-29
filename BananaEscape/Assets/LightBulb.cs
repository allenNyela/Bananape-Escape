using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    [SerializeField]
    GameObject lightLock;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Throwable") && lightLock != null)
        {
            if (Level1Manager.Instance.CanWin())
                Destroy(lightLock);
            else
            {
                Level1Manager.Instance.Loose("You can't knock anything down with those pesky cameras on!");
            }
        }
    }
}
