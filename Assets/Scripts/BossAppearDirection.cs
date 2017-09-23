using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppearDirection : MonoBehaviour {

	public Sprite boss_bg2;

	// Use this for initialization
	void Start () {
		Background.Instance.Sprite.sprite = boss_bg2;
	}

}
