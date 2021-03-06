﻿using UnityEngine;
using UnityEditor;

public class MapEditor : EditorWindow
{
	private int width;
	private int height;
	private GameObject node;
	private Transform nodeParent;
	private MapData data;

	[MenuItem("Window/Map Editor")]
	public static void ShowWindow()
	{
		GetWindow(typeof(MapEditor));
	}

	private void OnGUI()
	{
		GUILayout.Label("Map Generator");
		node = EditorGUILayout.ObjectField("Node", node, typeof(GameObject), false) as GameObject;
		nodeParent = EditorGUILayout.ObjectField("Node Parent", nodeParent, typeof(Transform), true) as Transform;
		data = EditorGUILayout.ObjectField("Map Data", data, typeof(MapData), true) as MapData;
		width = EditorGUILayout.IntField("Width:", width);
		height = EditorGUILayout.IntField("Height:", height);

		if (GUILayout.Button("Generate Map"))
		{
			GenerateMap();
			//nodeParent.gameObject.GetComponent<GraphData>().GenerateGraph(width, height);
		}
	}

	private void GenerateMap()
	{
		for (int i = nodeParent.childCount - 1; i >= 0; i--)
		{
			Transform child = nodeParent.GetChild(i);
			DestroyImmediate(child.gameObject);
		}

		data.width = width;
		data.height = height;

		for (int w = 0; w < width; w++)
		{
			for (int h = 0; h < height; h++)
			{
				var spawnedNode = Instantiate(node, nodeParent);
				spawnedNode.transform.position = new Vector3(w, 0, h);
			}
		}
	}
}