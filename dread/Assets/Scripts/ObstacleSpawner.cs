using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public int numObstacles = 10;
    public float spawnRadius = 5f;

    private void Start()
    {
        for (int i = 0; i < numObstacles; i++)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        Instantiate(obstaclePrefabs[randomIndex], transform.position + new Vector3(randomPosition.x, randomPosition.y, 0f), Quaternion.identity);
    }
}