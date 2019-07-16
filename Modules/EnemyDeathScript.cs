using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDeathScript : MonoBehaviour {

	private EnemyStats stats;
	public List<GameObject> objectsToDrop;

	void Start(){
		stats = GetComponent<EnemyStats> ();
	}

	void Update(){
		if (stats.health <= 0f) {
			DropStuff ();
			Destroy (gameObject);
		}
	}

	//Makes all objects in objectsToDrop drop to the ground on death
	public void DropStuff(){ 
		for (int i = 0; i < objectsToDrop.Count; i++) {
			objectsToDrop [i].GetComponent<Rigidbody> ().isKinematic = false;
			objectsToDrop [i].GetComponent<Rigidbody> ().useGravity = true;
			objectsToDrop [i].GetComponent<Collider> ().isTrigger = false;
			objectsToDrop [i].transform.SetParent (null);
		}
	}
}
