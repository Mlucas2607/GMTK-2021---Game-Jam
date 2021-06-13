using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    [Header("Variables")]
    public Transform camera;
    void Update() => transform.LookAt(camera, Vector3.up);
}
