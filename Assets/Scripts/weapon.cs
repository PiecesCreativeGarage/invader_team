using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {
	public int speed = 30;

	void Start ()
	{
		Invoke ("DestroySelf", 0.5f);

		GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
	}
		
	void DestroySelf()
	{
		Destroy (this.gameObject);
	}

}

