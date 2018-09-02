using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
	[SerializeField] Waypoint startWaypoint, endWaypoint;
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.down,
		Vector2Int.left,
		Vector2Int.right
	};

	// Use this for initialization
	void Start () {
		LoadBlocks();
		ColorStartAndEnd();
		ExploreNeighbours();
	}
	private void LoadBlocks() {
		Waypoint[] waypoints = FindObjectsOfType<Waypoint>();

		foreach (Waypoint waypoint in waypoints) {
			Vector2Int gridPos = waypoint.GetGridPos();
			if (grid.ContainsKey(gridPos)) {
				Debug.LogWarning("Skipping overlapping block " + waypoint);
			} else {
				grid.Add(gridPos, waypoint);
			}
		}
		print ("Loaded " + grid.Count + " blocks");
	}

	void ColorStartAndEnd() {
		startWaypoint.SetTopColor(Color.green);
		endWaypoint.SetTopColor(Color.red);
	}
	
	void ExploreNeighbours() {
		foreach(Vector2Int direction in directions) {
			Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
			try{
				grid[explorationCoordinates].SetTopColor(Color.blue);
			} catch {}
		}
	}
}
