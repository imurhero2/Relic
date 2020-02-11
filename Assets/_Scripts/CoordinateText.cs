using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class CoordinateText : MonoBehaviour
{
	public TMP_Text coordinateText;

	private void Update()
    {
		if (transform.hasChanged)
		{
			float x = Mathf.Round(transform.position.x);
			float z = Mathf.Round(transform.position.z);

			transform.position = new Vector3(x, 0, z);
			coordinateText.text = $"({x},{z})";
			gameObject.name = $"Node ({x},{z})";
		}
    }
}
