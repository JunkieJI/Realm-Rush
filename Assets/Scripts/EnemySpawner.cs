using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] float secondsBetweenSpawns = 2f;
	[SerializeField] EnemyMovement enemyPrefab;
	// Use this for initialization
	void Start () {
		StartCoroutine(RepeatedlySpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator RepeatedlySpawnEnemy() {
		while (true) {
			print("spawning");
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
