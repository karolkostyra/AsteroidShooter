using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;

    int gridRows = 6;
    int gridColumns = 6;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        Vector3 startPosition = new Vector3(-1*(gridColumns-1), 1*(gridRows-1),0);

        for (int i = 0; i < gridRows; i++)
        {
            for (int j = 0; j < gridColumns; j++)
            {
                Instantiate(asteroidPrefab,
                            new Vector3(-1 * (gridColumns - 1) + j*2, 1 * (gridRows - 1) - i*2, 0),
                            Quaternion.identity,
                            this.transform);
            }
        }
    }
}
