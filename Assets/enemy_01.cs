using UnityEngine;
using System.Collections;

public class enemy_01 : EnemyBase {
	public float speed = 0;

	// 爆発のPrefab
	public GameObject explosion;

	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
		Object prefab = Resources.Load ("deadSe");
		Instantiate (prefab);
	}

	// Update is called once per frame
	void Update () {
		if (PlayerAlive) {
			transform.position += -transform.right.normalized * speed;
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if (layerName == "Weapon") {
			// 弾の削除
			Destroy (c.gameObject);

			//爆発
			Explosion ();


			// エネミーの削除
			Dead ();
		}
	}
}
