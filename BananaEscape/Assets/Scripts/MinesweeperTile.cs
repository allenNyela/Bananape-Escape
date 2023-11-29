using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesweeperTile : MonoBehaviour
{
    bool isBomb;
    List<MinesweeperTile> neighbors;
    int numNeighborBombs;

    bool isRevealed;
    bool isMarked;

    private void Start()
    {
        isBomb = Random.Range(1, 5) == 5;
        numNeighborBombs = 0;
        isRevealed = false;
        isMarked = false;
    }

    public void InitNeighbors(List<MinesweeperTile> neighbors)
    { 
        foreach (MinesweeperTile neighbor in neighbors)
        {
            if (neighbor.isBomb)
                numNeighborBombs++;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRevealed = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            isMarked = true;
        }
    }
}
