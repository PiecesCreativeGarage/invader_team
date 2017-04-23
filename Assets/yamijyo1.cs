using UnityEngine;
using System.Collections;

public class yamijyo1 : MonoBehaviour {
	public int strength = 0;
	private int count = 0;
    public float speed = 15;	

	// PlayerBulletプレハブ
	public GameObject bullet;

	// 爆発のPrefab
	public GameObject explosion;

	// Use this for initialization
	void Awake() {
		if (PlayerStatus.instance.sprite != null) {
			this.GetComponent<SpriteRenderer>().sprite = PlayerStatus.instance.sprite;
			this.GetComponent<SpriteRenderer>().color = PlayerStatus.instance.color;
		}
	}

	// 爆発の作成
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y= Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;

		if (Input.GetButtonDown("Fire1")) {
			Instantiate(bullet, transform.position, transform.rotation);
		}
	}
		
	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if( layerName == "Enemy")
		{
			count++;
			// エネミーの削除
			Destroy(c.gameObject);

			if( strength <= count )
			{
				//爆発
				Explosion();
				// 弾の削除
				Destroy(gameObject);
			}
		}
	}
}
