﻿using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	// ※3/25作成中です

	// スクロールするスピード
	public float speed = 0.1f;

	void Update ()
	{
		// 時間によってxの値が0から1に変化していく。1になったら0に戻り、繰り返す。
		float x = Mathf.Repeat (Time.time * speed, 1);

		// Yの値がずれていくオフセットを作成
		Vector2 offset = new Vector2 (x, 0);

		// マテリアルにオフセットを設定する
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

}
