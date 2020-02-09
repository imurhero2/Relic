using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPathfinding : MonoBehaviour
{
    Vector3 currentPos = new Vector3();

    public void MoveToTile(int x, int y)
    {
        Dictionary<Node, float> distance = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();
    }
}
