using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageClear : MonoBehaviour {


	public GameObject rizarutogamen;
	public Text sucore;
	public Score Scorecountee;
	public Button Next;

	public Emitter emitter;
	// Use this for initialization
	void Start () {
		emitter.onEnd += () => {
			sucore.text = Scorecountee.getScore().ToString();
			rizarutogamen .gameObject .SetActive (true);
		};

		if (Next != null) {
			Next.onClick.AddListener 
	   (() => {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("病女2");
			});
		}
	}

}
