using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour {

	public float speed = 5;
	public float destroySec = 2;

	// Use this for initialization
	void Start () {
		Invoke ("DestroySelf", destroySec);
	}

	void DestroySelf() {
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += this.transform.right * speed * Time.deltaTime;
	}
}
