using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

	public Text score;
	int totalscore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore(int score){
		totalscore += score;
		this.score.text = "Score " + totalscore;
	}

	public int getScore(){
		return totalscore;
	}

}

