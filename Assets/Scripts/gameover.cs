using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour {

	public GameObject restart; 

	public GameObject backtotitle;

	void OnEnable() {
		if (ContinueCount.Count == 0) {
			backtotitle.SetActive (true);
		}
			
		if (ContinueCount.Count == 1) {
			restart.SetActive (true);
		}

		if (ContinueCount.Count == 2) {
			restart.SetActive (true);
		}
	
		if (ContinueCount.Count == 3) {
			restart.SetActive (true);
		}

	}

	public void onclick(){ 
		ContinueCount.Count--;
		UnityEngine.SceneManagement.SceneManager.LoadScene("病女");
	}
 
	public void onclickTitle(){
		ContinueCount.Count = 3;
		UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
	}

}
