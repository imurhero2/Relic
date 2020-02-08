using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class CoordinateText : MonoBehaviour
{
	public TMP_Text coordinateText;

	private void Start()
	{
		coordinateText.text = $"({transform.position.x},{transform.position.z})";
	}

	private void Update()
    {
		if (transform.hasChanged)
		{
			transform.position = new Vector3(Mathf.Floor(transform.position.x), 0, Mathf.Floor(transform.position.z));
			coordinateText.text = $"({transform.position.x},{transform.position.z})";
		}
    }
}
