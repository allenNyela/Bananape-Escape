using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackRetryButton : MonoBehaviour
{
    public void Retry(){
        LevelTransition.Instance.ResetLevel();
    }
}
