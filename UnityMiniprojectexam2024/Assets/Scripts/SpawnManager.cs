using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;
    PlotSpawner plotSpawner;
    ObstacleSpawner obstacleSpawner;
    CoinSpawner coinSpawner; // Add reference to the CoinSpawner

    public float initialSpawnDelay = 10f; // Delay before spawning starts

    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        plotSpawner = GetComponent<PlotSpawner>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();
        coinSpawner = GetComponent<CoinSpawner>(); // Initialize CoinSpawner

        // Spawn initial objects
        SpawnInitialContent();
    }

    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
        plotSpawner.SpawnPlot();

        // Spawn obstacles and coins on the new road segment
        float newRoadZ = roadSpawner.roads[roadSpawner.roads.Count - 1].transform.position.z;
        obstacleSpawner.SpawnObstacles(newRoadZ);
        coinSpawner.SpawnCoins(newRoadZ); // Spawn coins
    }

    private void SpawnInitialContent()
    {
        foreach (var road in roadSpawner.roads)
        {
            float roadZ = road.transform.position.z;
            if (roadZ > initialSpawnDelay)
            {
                obstacleSpawner.SpawnObstacles(roadZ);
                coinSpawner.SpawnCoins(roadZ); // Spawn coins on initial roads
            }
        }
    }
}
