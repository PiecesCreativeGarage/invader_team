using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueCount : MonoBehaviour {

	public int Count=3;
	public HorizontalLayoutGroup layout;
	public GameObject orgImage;
	GameObject[] lifeObjects;

	// Use this for initialization
	void Start () {
		lifeObjects = new GameObject[Count];
		for (int i = 0; i < Count; ++i) {
			GameObject go = Instantiate (orgImage);
			go.transform.SetParent( layout.transform );
			go.transform.localScale = Vector3.one;
			lifeObjects [i] = go;
		}
		Destroy (orgImage);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
