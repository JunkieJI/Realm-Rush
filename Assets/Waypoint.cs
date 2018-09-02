using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    const int gridSize = 10;
	Vector2Int gridPos;
	public int GetGridSize() {
		return gridSize;
	}

	public Vector2Int GetGridPos() {
		gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize);
		gridPos.y =	Mathf.RoundToInt(transform.position.z / gridSize);

		return gridPos;
	}

	public void SetTopColor(Color color) {
		MeshRenderer meshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
		meshRenderer.material.color = color;
	}
}
