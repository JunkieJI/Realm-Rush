﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] Transform targetEnemy;
	[SerializeField] float attackRange = 10f;
	[SerializeField] ParticleSystem projectileParticle;

	// Update is called once per frame
	void Update () {
		if (targetEnemy) {
			objectToPan.LookAt(targetEnemy);
			FireAtEnemy();
		} else {
			Shoot(false);
		}
	}

	void FireAtEnemy() {
		float distanceToEnemy = Vector3.Distance(targetEnemy.position, gameObject.transform.position);
		if (attackRange >= distanceToEnemy) {
			Shoot(true);
			
		} else {
			Shoot(false);
		}
	}
	
	void Shoot(bool isActive) {
		var emissionModule = projectileParticle.emission;
		emissionModule.enabled = isActive;
	}
}