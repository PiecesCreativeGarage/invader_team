using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEndLine : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D hitobj) {
		
		if(hitobj.gameObject.GetComponent<EnemyBase>() != null) {
			Destroy(hitobj.gameObject);
		}
	}
}
