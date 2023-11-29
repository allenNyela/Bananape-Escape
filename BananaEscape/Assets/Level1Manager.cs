using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Switch;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    public static Level1Manager Instance;

    [SerializeField]
    Canvas gameOverCanvas;

    [SerializeField]
    TextMeshProUGUI gameOverText;

    [SerializeField]
    LevelChangeArea LevelChangeArea;

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
    }

    bool cam1enabled = true, cam2enabled = true;

    public bool CanWin()
    {
        return !cam1enabled && !cam2enabled;
    }

    public void Win()
    {
        // winner winner chicken dinner!
        Debug.Log("Win!");
        LevelChangeArea.ChangeScene();
    }

    public void Loose(string lossMessage)
    {
        // haha! looser! ha! you loose! haha! fucking looser! look at this bozo! hahaha!
        Debug.Log("Lose!");
        gameOverText.text = lossMessage;
        gameOverCanvas.gameObject.SetActive(true);
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("ThomasPuzzle");
    }

    public void Quit()
    {
        //Return to main menu
        Debug.Log("Quit");
    }

    public void DisableCam(int camNum)
    {
        switch (camNum)
        {
            case 1:
                cam1enabled = false; 
                break;
            case 2:
                cam2enabled = false;
                break;
            default:
                break;
        }
    }

    public void EnableCam(int camNum)
    {
        switch (camNum)
        {
            case 1:
                cam1enabled = true;
                break;
            case 2:
                cam2enabled = true;
                break;
            default:
                break;
        }
    }
}
