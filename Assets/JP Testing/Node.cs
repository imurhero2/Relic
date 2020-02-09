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
