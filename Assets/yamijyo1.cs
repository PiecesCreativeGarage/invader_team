using UnityEngine;
using System.Collections;

public class yamijyo1 : MonoBehaviour {

    public float speed = 15;	

	// PlayerBulletプレハブ
	public GameObject bullet;

	// 爆発のPrefab
	public GameObject explosion;

	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}
	// Startメソッドをコルーチンとして呼び出す
	IEnumerator Start ()
	{
		while (true) {
			// 弾をプレイヤーと同じ位置/角度で作成
			Instantiate (bullet, transform.position, transform.rotation);
			// 0.05秒待つ
			yield return new WaitForSeconds (0.5f);
		}
	}

	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y= Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
	}


	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);


		if( layerName == "Enemy")
		{
			//爆発
			Explosion();
			// 弾の削除
			Destroy(c.gameObject);
		}
	}
    
}
