using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

	public int score;
	public event System.Action<int> onDead;

	void OnDestroy()
	{
		this.onDead (score);
	}
}
