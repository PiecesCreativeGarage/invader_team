using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	// ※3/25作成中です

	// スクロールするスピード
	public float speed = 0.1f;

	public static Background Instance {
		get { return s_instance; }
	}
	static Background s_instance;

	public SpriteRenderer Sprite {
		get;
		private set;
	}

	void Awake()
	{
		s_instance = this;
		Sprite = gameObject.GetComponentInChildren<SpriteRenderer> ();
	}

	void Update ()
	{
		enabled = false;	// FIXME:スクロール機能入れるならこの行を消す

		// 時間によってxの値が0から1に変化していく。1になったら0に戻り、繰り返す。
		float x = Mathf.Repeat (Time.time * speed, 1);

		// Yの値がずれていくオフセットを作成
		Vector2 offset = new Vector2 (x, 0);

		// マテリアルにオフセットを設定する
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

}
