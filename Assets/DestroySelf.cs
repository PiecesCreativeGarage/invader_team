using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	public float seconds = 0.5f;

	void Start ()
	{
		Invoke ("_DestroySelf", seconds);

	}

	void _DestroySelf()
	{
		Destroy (this.gameObject);
	}

}

