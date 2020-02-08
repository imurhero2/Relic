using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapEditor : EditorWindow
{
	public int width;
	public int height;

	[MenuItem("Window/Map Editor")]
	public static void ShowWindow()
	{
		GetWindow<MapEditor>("Map Editor");
	}

	private void OnGUI()
	{
		width = EditorGUILayout.IntField("Width:", width);
		height = EditorGUILayout.IntField("Height:", height);

		if (GUILayout.Button("Generate Map"))
		{
			GenerateMap();
		}
	}

	private void GenerateMap()
	{
		Debug.Log($"Generating Map of size {width}x{height}");
	}
}