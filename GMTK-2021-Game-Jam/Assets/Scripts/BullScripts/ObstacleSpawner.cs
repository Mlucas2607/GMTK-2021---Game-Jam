using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Variables")]
    public GameObject[] obstaclePrefabs;
    private void Start()
    {
        bool isActive = Random.Range(0, 2) > 0;
        if (isActive)
        {
            int rndNum = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[rndNum], this.transform);
        }
    }
}
