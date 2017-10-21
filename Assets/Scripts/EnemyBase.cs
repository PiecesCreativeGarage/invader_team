using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour {

	public static bool PlayerAlive = true;

	public static List<EnemyBase> s_list = new List<EnemyBase>();

	public event System.Action<int, bool> onDestroied;		// この敵が消滅したことを知りたいプログラムへのコールバック
	public event System.Action<int> onDead;
	int score = 50;				// この敵が持つスコア
	bool isDead = false;	// プレイヤーによって倒されたか

	void Awake()
	{
		s_list.Add (this);
	}

	/// <summary>
	/// Destroyが呼ばれた時に実行される
	/// </summary>
	void OnDestroy() {
		s_list.Remove (this);

		if (onDestroied != null) {
			onDestroied (score, isDead);
		}
	}

	/// <summary>
	/// 死んだ時の処理を書く
	/// </summary>
	protected virtual void Dead()
	{
		if (onDead != null)
			onDead (score);
		isDead = true;
		Destroy(gameObject);
	}
}
