using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour {

	public event System.Action<int, bool> onDestroied;		// この敵が消滅したことを知りたいプログラムへのコールバック
	int score;				// この敵が持つスコア
	bool isDead = false;	// プレイヤーによって倒されたか

	/// <summary>
	/// Destroyが呼ばれた時に実行される
	/// </summary>
	void OnDestroy() {
		onDestroied(score, isDead);
	}

	/// <summary>
	/// 死んだ時の処理を書く
	/// </summary>
	protected virtual void Dead()
	{
		isDead = true;
		Destroy(gameObject);
	}
}
