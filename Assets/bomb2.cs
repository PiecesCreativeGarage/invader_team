using UnityEngine;
using System.Collections;

public class bomb2 : MonoBehaviour {

	void Start ()
	{
		Invoke ("DestroySelf", 0.5f);

	}

	void DestroySelf()
	{
		Destroy (this.gameObject);
	}

}

