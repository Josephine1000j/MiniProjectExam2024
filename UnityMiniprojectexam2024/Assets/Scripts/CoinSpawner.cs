using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public List<GameObject> coins; // List of coin prefabs
    public float spawnZInterval = 5f; // Distance between coins along the road
    public int maxCoinsPerRow = 5; // Maximum coins in one line along the road
    public float roadWidth = 10f; // Width of the road
    public float spawnChance = 0.7f; // Chance to spawn coins per road segment
    public float coinHeight = 1f; // Height of the coins above the road

    public void SpawnCoins(float roadZPosition)
    {
        // Check if coins list is empty
        if (coins == null || coins.Count == 0)
        {
            Debug.LogWarning("No coin prefabs assigned to the CoinSpawner!");
            return;
        }

        // Random chance to skip spawning coins
        if (Random.value > spawnChance) return;

        // Random lateral offset for the entire line (shift left or right)
        float lateralOffset = Random.Range(-roadWidth / 2, roadWidth / 2);

        List<Vector3> usedPositions = new List<Vector3>();

        // Spawn coins in a straight line along the Z-axis
        for (int i = 0; i < maxCoinsPerRow; i++)
        {
            float zOffset = i * spawnZInterval; // Spread coins along the Z-axis
            Vector3 spawnPosition = new Vector3(lateralOffset, coinHeight, roadZPosition + zOffset);

            // Check for overlap with obstacles or other coins
            if (IsPositionClear(spawnPosition, usedPositions))
            {
                GameObject coinPrefab = coins[Random.Range(0, coins.Count)];
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

                // Mark this position as used
                usedPositions.Add(spawnPosition);
            }
        }
    }

    private bool IsPositionClear(Vector3 position, List<Vector3> usedPositions)
    {
        // Check overlap with obstacles
        Collider[] hitColliders = Physics.OverlapSphere(position, 1.5f); // Adjust radius as needed
        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Obstacle")) return false;
        }

        // Check overlap with other coins
        foreach (var usedPosition in usedPositions)
        {
            if (Vector3.Distance(usedPosition, position) < 1.5f) return false; // Adjust radius as needed
        }

        return true;
    }
}
