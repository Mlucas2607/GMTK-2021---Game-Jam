using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [Header("SpawnNode Settings")]
    public int spawnCount,spawnLimit;

    [Header("SpawnNode Variables")]
    public List<Transform> spawnNodes;
    public GameObject tilePrefab;

    [Header("RenderDistance")]
    public GameObject player;
    public float renderDistance;

    public List<GameObject> tiles;

    void Update()
    {
        SpawnTile();
        RenderTiles();
    }

    void RenderTiles()
    {
        for (int i = 0; i < tiles.Count; i++)
            tiles[i].SetActive(!CheckPlayerIsInDistanceToNode(tiles[i].transform));
    }

    void SpawnTile()
    {
        for (int i = 0; i < spawnNodes.Count; i++)
        {
            if (spawnCount >= spawnLimit)
            {
                spawnNodes.Remove(spawnNodes[i]);
                return;
            }

            if (CheckPlayerIsInDistanceToNode(spawnNodes[i]))
                return;

            Vector3 sPos = spawnNodes[i].position;
            Quaternion sRot = spawnNodes[i].rotation;

            GameObject curTile = Instantiate(tilePrefab,sPos,sRot);
            tiles.Add(curTile);
            spawnCount++;
            spawnNodes.Remove(spawnNodes[i]);
        }
    }

    bool CheckPlayerIsInDistanceToNode(Transform t)
    {
        bool isInRange;
        Vector3 pDis = player.transform.position;
        Vector3 tDis = t.position;

        float dist = Vector3.Distance(pDis, tDis);

        if (dist >= renderDistance)
            isInRange = true;
        else
            isInRange = false;
 
        return (isInRange);
    }
}
