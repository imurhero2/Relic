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
        Node current = null;
        List<Node> open = new List<Node>(); ;
        List<Node> closed = new List<Node>();
        int distance = 0;

        open.Add(graph.graph[(int)Math.Round(currentPos.x), (int)Math.Round(currentPos.y)]);

        while (open.Count > 0)
        {
            var lowest = open.Min();
            current = lowest;

            closed.Add(current);
            open.Remove(current);

            Debug.Log("(" +current.gameObject.transform.position.x + ", " + current.gameObject.transform.position.y+")");

            if (closed.Contains(target))
                break;

            var neighbors = current.neighbors;
            distance++;

            foreach(var neighbor in neighbors)
            {
                if (!closed.Contains(neighbor))
                {
                    continue;
                }
                if (!open.Contains(neighbor))
                {
                    neighbor.distance = distance +  neighbor.cost;
                    neighbor.estimate = GetEstimate(new Vector2(neighbor.gameObject.transform.position.x, neighbor.gameObject.transform.position.y), new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y));
                    neighbor.score = neighbor.distance + neighbor.estimate;

                    open.Add(neighbor);
                }
                else
                {
                    if(distance + neighbor.estimate < neighbor.cost)
                    {
                        neighbor.distance = distance;
                        neighbor.score = neighbor.distance + neighbor.estimate;
                        current = neighbor;
                    }
                }
            }
        }

        if(current != null)
        {
            foreach(var tile in closed)
            {
                Debug.Log("(" + tile.gameObject.transform.position.x + ", " + tile.gameObject.transform.position.y + ")");
                //move through these tiles
            }
        }

    }

    static int GetEstimate(Vector2 start, Vector2 end)
    {
        return (int)Math.Round(Math.Abs(end.x - start.x) + Math.Abs(end.y - start.y));
    }

}
