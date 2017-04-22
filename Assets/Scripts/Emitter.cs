using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

	public Object[] waves;

	int waveIndex;

	IEnumerator Start () {
		while ( waveIndex <= waves.Length ) {
			GameObject wave = (GameObject)GameObject.Instantiate (waves [waveIndex]);

			yield break;
		}
	}
}
