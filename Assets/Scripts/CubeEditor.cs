using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof (Waypoint))]
public class CubeEditor : MonoBehaviour {
    TextMesh textMesh;
	Waypoint waypoint;
	int gridSize;
	void Awake() {
		waypoint = GetComponent<Waypoint>();
		gridSize = waypoint.GetGridSize();
	}

    void Update() {
        SnapGrid();
		UpdateLabel();
    }

	void SnapGrid() {
        transform.position = new Vector3(
			waypoint.GetGridPos().x * gridSize,
			0f,
			waypoint.GetGridPos().y * gridSize
		);
	}

	void UpdateLabel() {
		textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = labelText;
        gameObject.name = labelText;
	}
}
