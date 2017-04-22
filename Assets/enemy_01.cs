using UnityEngine;
using System.Collections;

public class enemy_01 : MonoBehaviour {
	public int speed = -6;

	// 爆発のPrefab
	public GameObject explosion;

	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	// Use this for initialization
	void Start () {
		
		GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
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
			Destroy (gameObject);
		}
	}
}
