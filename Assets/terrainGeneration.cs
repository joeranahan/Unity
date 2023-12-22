using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainGeneration : MonoBehaviour
{
    public Terrain terrain;
    public float scale = 20.0f;

    void Start()
    {
        terrain = GetComponent<Terrain>();
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        TerrainData terrainData = terrain.terrainData;
        int width = terrainData.heightmapResolution;
        int height = terrainData.heightmapResolution;
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = Mathf.PerlinNoise(x / scale, y / scale);
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }
}