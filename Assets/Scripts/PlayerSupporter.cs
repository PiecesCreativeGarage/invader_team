﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSupporter : PlayerBase {

	EnemyBase target;

	float detectDistance = 20;
	float keepDistance = 5;

	Vector3 defaultPos;

	// Use this for initialization
	IEnumerator Start () {
		defaultPos = transform.position;

		while (true) {
			float timer = 0.5f;
			float speed = 10 * Time.deltaTime;

			float waitSec = 1;

			while (target == null) {
				waitSec -= Time.deltaTime;
				if (waitSec < 0) {
					transform.position = Vector3.MoveTowards (this.transform.position,
						defaultPos, speed * 2);
				}

				timer -= Time.deltaTime;
				if (timer < 0) {
					SearchEnemy ();
					timer = 0.5f;
				}
				yield return null;
			}

			while (target != null) {
				waitSec = 1;

				transform.position = Vector3.MoveTowards (this.transform.position,
					target.transform.position + -target.transform.right * keepDistance, speed);

				if (Vector3.Distance (this.transform.position, target.transform.position) <= keepDistance) {
					Fire (bullet);
					yield return new WaitForSeconds (0.2f);
				}

				if (target != null) {
					if (!IsInAngle(target.gameObject)) {
						target = null;
					}
				}
				yield return null;
			}
		}
	}

	bool IsInAngle(GameObject target) {
		Vector3 dir = target.transform.position - transform.position;
		return Vector3.Angle(dir, transform.right) < 60;
	}

	void SearchEnemy()
	{
		foreach (var e in EnemyBase.s_list) {
			if (!IsInAngle(e.gameObject)) {
				continue;
			}

			if(5 < e.transform.position.x) {
				continue;
			}

			if (Vector3.Distance (e.transform.position, transform.position) < detectDistance) {
				target = e;
				break;
			}
		}	
	}

}
