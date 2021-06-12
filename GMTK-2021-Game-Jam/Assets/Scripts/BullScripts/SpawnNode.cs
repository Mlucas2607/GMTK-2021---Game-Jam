using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour
{
    [Header("Variables")]
    public WorldGenerator wrldGen;
    private void Start()
    {
        wrldGen = FindObjectOfType<WorldGenerator>();
        wrldGen.spawnNodes.Add(this.transform);
    }
}
