using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	[SerializeField] private Transform camera;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float scrollSpeed;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private float minCameraHeight;
	[SerializeField] private float maxCameraHeight;

    void Update()
    {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		float scroll = Input.GetAxis("Mouse ScrollWheel");

		if (h != 0)
		{
			transform.position += moveSpeed * Time.deltaTime * h * transform.right; 
		}

		if (v != 0)
		{
			transform.position += moveSpeed * Time.deltaTime * v * transform.forward;
		}

		if (scroll != 0)
		{
			//var localDirection = camera.rotation * Vector3.forward;
			transform.position += scrollSpeed * Time.deltaTime * scroll * camera.forward;
		}

		if (Input.GetMouseButton(1))
		{
			transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
		}
	}
}
