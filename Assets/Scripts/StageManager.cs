﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {

	[System.Serializable]
	public class StageDef {
		public Sprite bg;
		public string stageName;
	}

	public StageDef[] stage;
	public SpriteRenderer bg;
	public Text stageNameText;

	public static int CurrentStage = 0;

	void Awake() {
		if (CurrentStage < stage.Length) {
			StageDef s = stage[CurrentStage];
			bg.sprite = s.bg;
			stageNameText.text = s.stageName;
		}
		else {
			UnityEngine.SceneManagement.SceneManager.LoadScene("Clear");
		}
	}

	public static void GoNextStage() {
		CurrentStage++;

		UnityEngine.SceneManagement.SceneManager.LoadScene("病女");
	}

}
