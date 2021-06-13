using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Variables")]
    public Obstacle[] obstacles;

    public float minRandomnessX;
    public float maxRandomnessX;
    public float minRandomnessZ;
    public float maxRandomnessZ;
    
    private void Start()
    {
        bool isActive = Random.Range(0, 2) > 0;
        if (isActive)
        {
            Vector3 rndLocation = transform.position;
            rndLocation.x += Random.Range(minRandomnessX, maxRandomnessX);
            rndLocation.z += Random.Range(minRandomnessZ, maxRandomnessZ);
            transform.position = rndLocation;
            
            Obstacle obstacle = obstacles[Random.Range(0, obstacles.Length)];

            Vector3 rndScale = transform.localScale;
            rndScale.x += Random.Range(obstacle.minScaleRandomnessX, obstacle.maxScaleRandomnessX);
            rndScale.y += Random.Range(obstacle.minScaleRandomnessY, obstacle.maxScaleRandomnessY);
            rndScale.z += Random.Range(obstacle.minScaleRandomnessZ, obstacle.maxScaleRandomnessZ);
            transform.localScale = rndScale;
            
            Vector3 rndRotation = transform.eulerAngles;
            rndRotation.x += Random.Range(obstacle.minRotationRandomnessX, obstacle.maxRotationRandomnessX);
            rndRotation.y += Random.Range(obstacle.minRotationRandomnessY, obstacle.maxRotationRandomnessY);
            rndRotation.z += Random.Range(obstacle.minRotationRandomnessZ, obstacle.maxRotationRandomnessZ);
            transform.eulerAngles = rndRotation;

            Instantiate(obstacle.prefab, transform);
        }
    }

    [System.Serializable]
    public struct Obstacle
    {
        public GameObject prefab;
        
        [Space(1f)]
        [Header("Random Scale")]
        public float minScaleRandomnessX;
        public float maxScaleRandomnessX;
        public float minScaleRandomnessY;
        public float maxScaleRandomnessY;
        public float minScaleRandomnessZ;
        public float maxScaleRandomnessZ;
        
        [Space(1f)]
        [Header("Random Rotation")]
        public float minRotationRandomnessX;
        public float maxRotationRandomnessX;
        public float minRotationRandomnessY;
        public float maxRotationRandomnessY;
        public float minRotationRandomnessZ;
        public float maxRotationRandomnessZ;
    }
}
