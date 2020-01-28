using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileType
{

    public string name;
    public GameObject tilePrefab; //We're going to want these to be a single mesh later
                                 //But that's complicated and for now game objects will work

    public bool isWalkable = true;
    public int movementCost = 1;

}
