using UnityEngine;
using System.Collections;

public class yamijyo1 : PlayerBase {

	public GameObject gameover;

	// Use this for initialization
	void Awake() {
		EnemyBase.PlayerAlive = true;

		if (PlayerStatus.instance.sprite != null) {
			this.GetComponent<SpriteRenderer>().sprite = PlayerStatus.instance.sprite;
			this.GetComponent<SpriteRenderer>().color = PlayerStatus.instance.color;
		}
	}

	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y= Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;

		if (Input.GetButtonDown("Fire1")) {
			Fire (bullet);
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			Instantiate(prefabMeteo, Vector3.zero, Quaternion.identity);
		}
	}

	protected override void OnDead ()
	{
		base.OnDead ();

		gameover.SetActive (true);
		EnemyBase.PlayerAlive = false;

	}
}
