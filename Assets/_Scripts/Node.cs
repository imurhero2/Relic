using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
	Default,
	Rough,
	Wall
}

[ExecuteInEditMode]
public class Node : MonoBehaviour
{
	public NodeType nodeType = NodeType.Default;
	public MeshRenderer meshRenderer;
	public Material defaultMat;
	public Material roughMat;
	public Material wallMat;

	//Pierre's Changes
	public int cost;
	public bool walkable;
	//private const int infinity = int.MaxValue;

	public List<Node> neighbors;

	public int distance;
	public int score;
	public int estimate;

	private int xCoord;
	private int zCoord;

	private void Start()
	{
		xCoord = Mathf.RoundToInt(transform.position.x);
		zCoord = Mathf.RoundToInt(transform.position.z);
		Map.nodes[xCoord, zCoord] = this;
		GenerateNeighbors(); // Need to wait until Map.nodes is fully populated
	}

	public void GenerateNeighbors()
	{
		neighbors = new List<Node>();
		if (zCoord + 1 < Map.instance.data.height)	neighbors.Add(Map.nodes[xCoord, zCoord + 1]); // Up
		if (xCoord + 1 < Map.instance.data.width)	neighbors.Add(Map.nodes[xCoord + 1, zCoord]); // Right
		if (zCoord - 1 >= 0)						neighbors.Add(Map.nodes[xCoord, zCoord - 1]); // Down
		if (xCoord - 1 >= 0)						neighbors.Add(Map.nodes[xCoord - 1, zCoord]); // Left
	}

	void Update()
    {
		switch (nodeType)
		{
			case NodeType.Default:
				meshRenderer.material = defaultMat;
				cost = 1;
				walkable = true;
				break;
			case NodeType.Rough:
				meshRenderer.material = roughMat;
				cost = 2;
				walkable = true;
				break;
			case NodeType.Wall:
				meshRenderer.material = wallMat;
				//cost = infinity;
				walkable = false;
				break;
			default:
				break;
		}
	}
}
