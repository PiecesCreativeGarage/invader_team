using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {
	public int strength = 0;
	protected int count = 0;
	public float speed = 15;	

	// PlayerBulletプレハブ
	public GameObject bullet;

	public GameObject prefabMeteo;

	// 爆発のPrefab
	public GameObject explosion;


	// 爆発の作成	
	void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	protected void Fire(GameObject prefab)
	{
		Instantiate(prefab, transform.position, transform.rotation);
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if( layerName == "Enemy")
		{
			strength--;
			// エネミーの削除
			Destroy(c.gameObject);

			if( strength == 0 )
			{
				//爆発
				Explosion();
				// 弾の削除
				Destroy(gameObject);

				this.OnDead ();
			}
		}
	}

	protected virtual void OnDead()
	{
		
	}
}
