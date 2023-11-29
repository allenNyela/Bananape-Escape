using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupManager : MonoBehaviour
{
    public static PickupManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    PlayerPlatformer player;

    [SerializeField]
    float pickUpRadius;

    public float PickupRadius { get { return pickUpRadius; } }

    public void GiveToPlayer(GameObject gameObject)
    {
        float dist = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if (player.heldObject != gameObject && dist < pickUpRadius)
            player.heldObject = gameObject;
    }
}
