using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPathfinding : MonoBehaviour
{
    Vector3 currentPos = new Vector3();
    public GraphData graph;
    public int movementSpeed;

    public void MoveToTile(Node target)
    {
        Node currentNode = null;
        List<Node> openNodes = new List<Node>(); ;
        List<Node> closedNodes = new List<Node>();
        int distance = 0;

        openNodes.Add(graph.graph[(int)Math.Round(currentPos.x), (int)Math.Round(currentPos.y)]);

        while (openNodes.Count > 0)
        {
            var lowest = openNodes.Min();
            currentNode = lowest;

            closedNodes.Add(currentNode);
            openNodes.Remove(currentNode);

			Debug.Log($"({currentNode.gameObject.transform.position.x}, {currentNode.gameObject.transform.position.y})");

			if (closedNodes.Contains(target))
                break;

            distance++; // Needs to take into account cost of node

            foreach(var neighbor in currentNode.neighbors)
            {
                if (!closedNodes.Contains(neighbor))
                {
                    continue;
                }
                if (!openNodes.Contains(neighbor))
                {
                    neighbor.distance = distance +  neighbor.cost;
                    neighbor.estimate = GetEstimate(new Vector2(neighbor.gameObject.transform.position.x, neighbor.gameObject.transform.position.y), new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y));
                    neighbor.score = neighbor.distance + neighbor.estimate;

                    openNodes.Add(neighbor);
                }
                else
                {
                    if(distance + neighbor.estimate < neighbor.cost)
                    {
                        neighbor.distance = distance;
                        neighbor.score = neighbor.distance + neighbor.estimate;
                        currentNode = neighbor;
                    }
                }
            }
        }

        if(currentNode != null)
        {
            foreach(var tile in closedNodes)
            {
                Debug.Log($"({tile.gameObject.transform.position.x}, {tile.gameObject.transform.position.y}");
                //move through these tiles
            }
        }

    }

    static int GetEstimate(Vector2 start, Vector2 end)
    {
        return (int)Math.Round(Math.Abs(end.x - start.x) + Math.Abs(end.y - start.y));
    }

}
