using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphData : MonoBehaviour
{
    public Node[,] graph;

    public void GenerateGraph(int width, int height)
    {
        graph = new Node[width, height];

		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{

				if(x>0)
					graph[x, y].neighbors.Add( graph[x - 1, y]);
				if(x > width - 1)
					graph[x, y].neighbors.Add(graph[x + 1, y]);
				if (y > 0)
					graph[x, y].neighbors.Add(graph[x, y - 1]);
				if (y > height - 1)
					graph[x, y].neighbors.Add(graph[x + 1, y + 1]);
			}
		}
	}
}
