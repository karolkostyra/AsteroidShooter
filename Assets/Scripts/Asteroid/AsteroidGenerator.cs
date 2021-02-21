using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;

    [SerializeField] private int gridSize = 6;
    [SerializeField] [Range(1,10)] private int cellsDistance = 2;

    private Vector3 startPosition;
    private int corrector;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        if (gridSize % 2 != 0)
        {
            corrector = 1;
        }
        else
        {
            corrector = 0;
        }

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Instantiate(asteroidPrefab,
                            new Vector3(-cellsDistance * (gridSize - 1) + cellsDistance*(j * 2 + corrector),
                                        cellsDistance * (gridSize - 1) - cellsDistance *(i * 2 + corrector), 0),
                                        Quaternion.identity, this.transform);
            }
        }
    }
}