using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesweepManager : MonoBehaviour
{
    public static MinesweepManager Instance;

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

    public Canvas keypadCanvas;

    public bool keypadIsVisible = false;
    public int boardSize;

    MinesweeperTile[,] tiles;

    private void Start()
    {
        tiles = new MinesweeperTile[boardSize, boardSize];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                mineField[i, j] = Random.Range(0, 9);
                discoveredNums[i, j] = false;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (mineField[i, j] == 0)
                    discoveredNums[i, j] = true;       
            }
        }
    }
}
