using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : yamijyo1 {

	// Use this for initialization
	void Awake() {
		if (PlayerStatus.instance.sprite != null) {
			this.GetComponent<SpriteRenderer> ().sprite = PlayerStatus.instance.sprite;
			this.GetComponent<SpriteRenderer> ().color = PlayerStatus.instance.color;
		}
	}
}
