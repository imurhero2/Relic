using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public TileType[] tileTypes;
    public int[,] tiles;

    [SerializeField] private int mapSizeX = 10;
    [SerializeField] private int mapSizeY = 10;

    void Start()
    {
        tiles = new int[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }

        //Testing Walls
        tiles[4, 4] = 2;
        tiles[5, 4] = 2;
        tiles[6, 4] = 2;
        tiles[7, 4] = 2;
        tiles[8, 4] = 2;

        tiles[4, 5] = 2;
        tiles[4, 6] = 2;
        tiles[8, 5] = 2;
        tiles[8, 6] = 2;
        //---------------

        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                TileType type = tileTypes[tiles[x, y]];
                Instantiate( type.tilePrefab, new Vector3(Convert.ToSingle(x), 0, Convert.ToSingle(y)), Quaternion.identity);
            }
        }
    }

}
