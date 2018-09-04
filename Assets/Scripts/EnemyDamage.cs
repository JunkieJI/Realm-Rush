using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	[SerializeField] Collider collisionMesh;
	[SerializeField] int hitPoints = 10;

	void OnParticleCollision(GameObject other) {
		ProcessHit();
		if (hitPoints < 1) {
			KillEnemy();
		}
	}

	void ProcessHit() {
		hitPoints -= 1;
	}

	void KillEnemy() {
		Destroy(gameObject);
	}
}
