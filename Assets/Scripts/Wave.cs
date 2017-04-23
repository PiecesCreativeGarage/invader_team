using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	EnemyBase[] enemies;

	int left_enemies;
	int score;

	void Awake()
	{
		this.enemies = this.gameObject.GetComponentsInChildren<EnemyBase> ();
		this.left_enemies = this.enemies.Length;
		foreach (var e in enemies) {
			e.onDestroied += this.OnEnemyDestroied;
		}
	}

	/// <summary>
	/// 敵が
	/// </summary>
	void OnEnemyDestroied(int score, bool is_dead) {

		if (is_dead) {
			this.score += score;
		}

		left_enemies--;
		if (left_enemies == 0) {
			Debug.Log("全滅しました");
		}
	}
}
