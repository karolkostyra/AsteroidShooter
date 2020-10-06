using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    public GameObject[] prefabs;


    // Start is called before the first frame update
    void Start()
    {
        Vector3[] spawnPositions = new Vector3[] { new Vector3(1.2f, 0.5f, 10f),
                                               new Vector3(-0.2f, 0.5f, 10f),
                                               new Vector3(0.5f, 1.3f, 10f),
                                               new Vector3(0.5f, -0.3f, 10f)};


        int camSize = (int)Camera.main.orthographicSize;

        Vector3 q = Camera.main.ViewportToWorldPoint(spawnPositions[0]);
        Vector3 w = Camera.main.ViewportToWorldPoint(spawnPositions[1]);
        Vector3 e = Camera.main.ViewportToWorldPoint(spawnPositions[2]);
        Vector3 r = Camera.main.ViewportToWorldPoint(spawnPositions[3]);

        prefabs[0].transform.position = new Vector3(q.x, q.y + camSize, q.z);
        prefabs[1].transform.position = new Vector3(w.x, w.y - camSize, w.z);
        prefabs[2].transform.position = new Vector3(e.x + camSize, e.y, e.z);
        prefabs[3].transform.position = new Vector3(r.x - camSize, r.y, r.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
