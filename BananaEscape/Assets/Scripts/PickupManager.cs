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

    public void GiveToPlayer(GameObject gameObject)
    {
        if (player.heldObject != gameObject)
            player.heldObject = gameObject;
    }
}
