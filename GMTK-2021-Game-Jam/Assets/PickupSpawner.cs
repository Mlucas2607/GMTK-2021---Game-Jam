using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    private void Start()
    {
        bool isSpawned = Random.Range(0, 100) > 80;
        int rndNum = Random.Range(0, prefabs.Length);
        if(isSpawned)
            Instantiate(prefabs[rndNum], transform);
    }
}
