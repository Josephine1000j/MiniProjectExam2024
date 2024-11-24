using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles; // List to hold obstacle prefabs
    public float spawnZInterval = 7f; // Distance between obstacle spawns
    private float lastSpawnZ = 0f;

    public void SpawnObstacles(float roadZPosition)
    {
        // Only spawn if the Z position is sufficiently far ahead of the player to avoid spawning too early
        if (roadZPosition > lastSpawnZ + spawnZInterval)
        {
            lastSpawnZ = roadZPosition;

            // Add a random chance for each spawn, so we don't spawn obstacles on every single road segment
            if (Random.Range(0f, 1f) < 0.9f)  // % chance to spawn an obstacle
            {
                // Spawn an obstacle at a random X position on the road
                float randomX = Random.Range(-5f, 5f); // Adjust for the road width
                GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];

                Instantiate(obstacle, new Vector3(randomX, -0.01f, roadZPosition), Quaternion.identity);
            }
        }
    }
}
