using UnityEngine;
using System.Collections;

public class SafetyNetScript : MonoBehaviour {

	public Transform getBackThere;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			PlayerStats.stats.TakeDamage (10f);
			other.transform.position = getBackThere.position;
		}
	}
}
