using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

	public event System.Action onEnd;	// 全Wave終了したことを知りたい人へのコールバック機能

	public Object[] waves;		// 出現させるWaveたち
	int waveIndex;				// 現在のWave番号

	IEnumerator Start () {
		while ( waveIndex < waves.Length ) {
			// Waveを生成する
			GameObject go_wave = (GameObject)GameObject.Instantiate (waves [waveIndex]);
			Wave wave = go_wave.GetComponent<Wave>();
			while (!wave.IsDestroied) {
				// Waveの敵全滅待ち
				yield return null;
			}

			// 次のWaveへ
			waveIndex++;
		}

		if(onEnd != null) {
			// 全Wave終了したことを通知する
			onEnd();
		}
	}
}
