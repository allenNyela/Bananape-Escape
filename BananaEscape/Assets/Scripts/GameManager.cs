using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("the game over canvas to display")]private GameObject gameOverCanvas;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get{
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    _instance = go.AddComponent<GameManager>();
                    Debug.Log("Generating new GameManager");
                }
            }
            return _instance;
        }
    }
    // Start is called before the first frame update
    private bool paused = false;

    public void Start(){
        if(gameOverCanvas)
            gameOverCanvas.SetActive(false);
            
    }
    public void Pause(bool paused){
        this.paused = paused;
    }

    public bool isPlaying(){
        return !paused && !gameOverCanvas.activeSelf;
    }

    public void GameOver(){
        gameOverCanvas.SetActive(true);
        paused = true;
    }
}
