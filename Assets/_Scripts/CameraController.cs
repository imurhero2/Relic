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

	[SerializeField] private Material highlight;

	private Collider currentCollider = null;

    void Update()
    {
		
		PlayerSelect();
		TileHover();
		CameraMovement();

	}

	private void PlayerSelect()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.CompareTag("Player"))
				{
					Debug.Log($"Player Selected \n Location: {hit.collider.transform.position.x}, {hit.collider.transform.position.z}");
					//Run Script that will create highlighted tiles
				}
			}
		}
	}

	private void TileHover()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			if (currentCollider != hit.collider)
			{
				if (hit.collider.CompareTag("Tile"))
				{
					Debug.Log($"Tile: {hit.collider.name}, {hit.collider.gameObject.GetComponent<Node>().nodeType}");
					//I imagine this will be hooked up to UI at some point with tile info
					
				}
				currentCollider = hit.collider;
			}
		}
	}

	private void CameraMovement()
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
