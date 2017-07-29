using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

	public yamijyo1 player;
	public Text life;
	public HorizontalLayoutGroup layout;
	public GameObject orgImage;

	GameObject[] lifeObjects;
	int crntLife;

	// Use this for initialization
	void Start () {
		crntLife = player.strength;
		lifeObjects = new GameObject[player.strength];
		for (int i = 0; i < player.strength; ++i) {
			GameObject go = Instantiate (orgImage);
			go.transform.SetParent( layout.transform );
			go.transform.localScale = Vector3.one;
			lifeObjects [i] = go;
		}
		Destroy (orgImage);
	}

	// Update is called once per frame
	void Update () {
		if (crntLife != player.strength) {
			int diff = crntLife - player.strength;
			for (int i = 0; i < diff; i++) {
				// ライフ減らす
				Destroy (lifeObjects [crntLife - 1 - i]);
			}
			crntLife = player.strength;
		}
		//life.text = "Life" + player.strength.ToString();
	}
}
