using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackMenuButton : MonoBehaviour
{
    [SerializeField, Tooltip("the name of the main menu scene")]private string menuString = "MainMenu";
    
    public void MainMenu(){
        LevelTransition.Instance.SweepIn(menuString);
    }
}
