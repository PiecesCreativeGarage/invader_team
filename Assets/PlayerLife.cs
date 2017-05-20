using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

	public yamijyo1 player;
	public Text life;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		life.text = "Life" + player.strength.ToString();
	}
}
