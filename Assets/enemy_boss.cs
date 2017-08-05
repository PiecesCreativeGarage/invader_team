using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_boss : EnemyBase {

	const float MAX_SPEED = 6;

	public int life = 5;
	public float speed = 6;

	// 爆発のPrefab
	public GameObject explosion;

	public float stopline;

	bool isMoving = true;
	float updownMoveRange = 3;

	float baseYpos;
	float elapsedTime = 0;

	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	void Update(){
		if (isMoving) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			if (this.transform.position.x < stopline) {
				isMoving = false;
				baseYpos = transform.position.y;
			}
		} else {
			float move = Mathf.Sin(elapsedTime) * updownMoveRange;
			elapsedTime += Time.deltaTime;

			float y = move + baseYpos;
			Vector3 pos = transform.position;
			pos.y = y;
			transform.position = pos;
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		// 弾の削除
		if (layerName == "Weapon") {
			Destroy(c.gameObject);

			life--;
			if (0 < life) {
				return;
			}
			else {
				//爆発
				Explosion();

				// エネミーの削除
				Dead();
			}
		}
	}
}
