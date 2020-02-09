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
	//public List<Node> neighbors;

	//public Node()
	//{
	//	neighbors = new List<Node>();
	//}
	//*************

    void Update()
    {
		switch (nodeType)
		{
			case NodeType.Default:
				meshRenderer.material = defaultMat;
				break;
			case NodeType.Rough:
				meshRenderer.material = roughMat;
				break;
			case NodeType.Wall:
				meshRenderer.material = wallMat;
				break;
			default:
				break;
		}
	}
}
