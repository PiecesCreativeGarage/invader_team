using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_boss : EnemyBase {

	public int life = 5;

	public int speed = 6;

	// 爆発のPrefab
	public GameObject explosion;

	public float stopline;

	bool isMoving = true;
	float updownMoveRange = 5;
	float moveVec = 1;

	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	// Use this for initialization
	void Start () {
	}

	void Update(){
		if (isMoving) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			if (this.transform.position.x < stopline) {
				isMoving = false;
			}
		} else {
			Vector3 pos = transform.position;
			float dir = Mathf.Sin (moveVec);
			float max = updownMoveRange * dir;
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		life--;
		if (0 < life) {
			return;
		}

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
