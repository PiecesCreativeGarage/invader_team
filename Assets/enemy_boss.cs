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
	float updownMoveRange = 5;
	float moveDir = 1;

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
			float max = updownMoveRange * moveDir;
			pos.y = Mathf.SmoothDamp(pos.y, max, ref speed, 0.5f, MAX_SPEED);
			transform.position = pos;
			if (Mathf.Abs(max) - Mathf.Abs(pos.y) <= 0.5f) {
				speed = 0;
				moveDir *= -1;
			}
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
