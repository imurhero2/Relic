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

	public Node()
	{
		neighbors = new List<Node>();
	}
	//*************

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
