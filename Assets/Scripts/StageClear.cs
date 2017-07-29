using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageClear : MonoBehaviour {
	public Text clear;
	public Emitter emitter;
	// Use this for initialization
	void Start () {
		emitter.onEnd += () => {
			clear.gameObject.SetActive (true);
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
