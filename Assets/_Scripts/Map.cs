using UnityEngine;

public class Map : MonoBehaviour
{
	public static Map instance;
	public static Node[,] nodes;
	public MapData data;

	public int nodeX;
	public int nodeZ;

	private void Awake()
	{
		instance = this;
		nodes = new Node[data.width, data.height];
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log(nodes[nodeX, nodeZ].neighbors.Count);
			foreach (var neighbor in nodes[nodeX, nodeZ].neighbors)
			{
				Debug.Log($"Neighbor: {neighbor.transform.position}");
			}
		}
	}
}
