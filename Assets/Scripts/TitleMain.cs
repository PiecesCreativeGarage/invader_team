using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene(string scene_name)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (scene_name);
	}
}
