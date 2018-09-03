using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	Queue<Waypoint> queue = new Queue<Waypoint>();

	bool isRunning = true;

	Vector2Int[] directions = {
		Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
	};

	// Use this for initialization
	void Start () {
		LoadBlocks();
		ColorStartAndEnd();
		PathFind();
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

	private void PathFind() {
		queue.Enqueue(startWaypoint);
		while (queue.Count > 0 && isRunning) {
			Waypoint searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;
			print ("Searching from " + searchCenter);
			HaltIfEndFound(searchCenter);
			ExploreNeighbours(searchCenter);
		}
		print ("Finished pathfinding?");
	}

	private void HaltIfEndFound(Waypoint searchCenter) {
		if (searchCenter == endWaypoint) {
			print ("Searching from endnode, therefore stopping");
			isRunning = false;
		}
	}

	private void ExploreNeighbours(Waypoint from) {
		if (!isRunning) { return; }
		foreach(Vector2Int direction in directions) {
			Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
			try{
				QueueNewNeighbours(neighbourCoordinates);
			} catch {}
		}
	}

	private void QueueNewNeighbours(Vector2Int neighbourCoordinates) {
		Waypoint neighbour = grid[neighbourCoordinates];
		if (!neighbour.isExplored) {
			neighbour.SetTopColor(Color.blue);
			queue.Enqueue(neighbour);
			print ("queueing " + neighbour);
		}
	}
}
