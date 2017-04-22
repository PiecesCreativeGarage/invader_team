using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	GameObject[] enemies;

	void Awake()
	{
		this.enemies = this.gameObject.GetComponents<GameObject> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
