using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{

    private int initAmount = 5;
    private float plotSize = 40f;
    private float xPosLeft = -29.5f;
    private float xPosRight = 29.5f;
    private float lastZPos = 0f;

    public List<GameObject> plots; 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnPlot();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlot()
    {
        GameObject plotLeft = plots[Random.Range(0, plots.Count)];
        GameObject plotRight = plots[Random.Range(0, plots.Count)];

        float zPos = lastZPos + plotSize;

        Instantiate(plotLeft, new Vector3(xPosLeft, 0.05f, zPos), plotLeft.transform.rotation);
        Instantiate(plotRight, new Vector3(xPosRight, 0.05f, zPos), new Quaternion(0, 180, 0, 0));

        lastZPos += plotSize;

    }
}
