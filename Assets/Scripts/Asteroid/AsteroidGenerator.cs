using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    [SerializeField] int gridSize = 6;

    Vector3 startPosition;
    int corrector;

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
                            new Vector3(-1 * (gridSize - 1) + j * 2 + corrector, 1 * (gridSize - 1) - i * 2 + corrector, 0),
                            Quaternion.identity,
                            this.transform);
            }
        }
    }
}