using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_boss : EnemyBase {

	const float MAX_SPEED = 6;

	public int life = 5;
	int init_life;
	public float speed = 6;

	// 爆発のPrefab
	public GameObject explosion;

	public float stopline;

	public GameObject bullet;

	public AudioSource shotvoice;

	// 第二携帯
	public GameObject transform_1;
	public GameObject transform_2;


	bool isMoving = true;
	float updownMoveRange = 3;

	float baseYpos;
	float elapsedTime = 0;

	IEnumerator fire;

	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	void Awake()
	{
		init_life = life;
	}

	void Update(){

		if (!PlayerAlive) {
			return;
		}

		if (isMoving) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			if (this.transform.position.x < stopline) {
				isMoving = false;
				baseYpos = transform.position.y;
				this.fire = Fire ();
				StartCoroutine (this.fire);
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

	IEnumerator Fire(){


		while (true) {
			yield return new WaitForSeconds (0.5f);
			shotvoice.Play ();

			GameObject aaa = GameObject.Instantiate (bullet);
			aaa.transform.position = transform.position;
			Rigidbody2D bbb = aaa.GetComponent<Rigidbody2D> ();
			bbb.AddForce (Vector2.left*1000);
		}

	}


	void OnTriggerEnter2D (Collider2D c)
	{
		if (!enabled)
			return;

		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		// 弾の削除
		if (layerName == "Weapon") {
			Destroy(c.gameObject);

			life = Mathf.Clamp(--life, 0, life);
			if (0 < life) {
				return;
			}
			else {
				//爆発
				Explosion();

				if (transform_2 == null) {
					// エネミーの削除
					Dead ();
				} else {
					StartCoroutine( Transform () );
				}
			}
		}
	}

	IEnumerator Transform()
	{
		enabled = false;

		if (this.fire != null) {
			StopCoroutine (this.fire);
		}
		SpriteRenderer sp = transform_1.GetComponentInChildren<SpriteRenderer> ();
		Vector3 pos = transform.localPosition;

		float dir = 1;
		while(0 < sp.color.a) {
			Color col = sp.color;
			col.a -= 0.02f;
			sp.color = col;
			transform_1.transform.localPosition = pos + (Vector3.right * 1f * dir);
			dir *= -1;	
			yield return null;
		}

		yield return new WaitForSeconds (0.5f);

		transform_1.gameObject.SetActive (false);
		transform_2.gameObject.SetActive (true);

		SpriteRenderer sp_2 = transform_2.GetComponentInChildren<SpriteRenderer> ();
		Color col_2 = sp_2.color;
		col_2.a = 0;
		sp_2.color = col_2;

		while(sp_2.color.a < 1) {
			col_2.a += 0.05f;
			sp_2.color = col_2;
			yield return null;
		}

		transform_2 = null;

		life = init_life;

		// 2発撃たせる
		StartCoroutine (Fire ());
		StartCoroutine (Fire ());

		enabled = true;
	}
}
		