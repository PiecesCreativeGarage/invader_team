using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class yamijyo1 : PlayerBase {

	public GameObject gameover;
	public LeftJoystick controller;

	public Button shoot;
	public Button meteo;

	// Use this for initialization
	void Awake() {
		EnemyBase.PlayerAlive = true;

		if (PlayerStatus.instance.sprite != null) {
			this.GetComponent<SpriteRenderer>().sprite = PlayerStatus.instance.sprite;
			this.GetComponent<SpriteRenderer>().color = PlayerStatus.instance.color;
		}

		Button.ButtonClickedEvent ev = new Button.ButtonClickedEvent();
		ev.AddListener(() => {
			Fire(bullet);
		});
		shoot.onClick = ev;

		ev = new Button.ButtonClickedEvent();
		ev.AddListener(() => {
			Instantiate(prefabMeteo, Vector3.zero, Quaternion.identity);
		});
		meteo.onClick = ev;

	}

	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y= Input.GetAxisRaw("Vertical");
		float coef = 1f;
		if (controller != null && controller.isActiveAndEnabled) {
			Vector3 dir = controller.GetInputDirection();
			x = dir.x;
			y = dir.y;
			coef = 0.6f;
		}

		Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed * coef;

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
