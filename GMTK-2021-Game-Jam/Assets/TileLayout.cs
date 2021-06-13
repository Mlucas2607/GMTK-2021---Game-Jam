using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLayout : MonoBehaviour
{
    public GameObject[] layouts;
    private void Start()
    {
        int rndNum = Random.Range(0, layouts.Length);

        for (int i = 0; i < layouts.Length; i++)
            layouts[i].SetActive(false);

        layouts[rndNum].SetActive(true);
    }
}
