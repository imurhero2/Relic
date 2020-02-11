using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map Data", menuName = "ScriptableObjects/Map Data", order = 1)]
public class MapData : ScriptableObject
{
	public int width;
	public int height;
}
