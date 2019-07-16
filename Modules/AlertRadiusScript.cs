using UnityEngine;
using System.Collections;

public class AlertRadiusScript : MonoBehaviour {

	private EnemyStatesAI enemy;

	void Start(){
		enemy = GetComponentInParent<EnemyStatesAI> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			enemy.currentState.OnTriggerEnter (other);
		}
	}
	void OnTriggerStay(Collider other){
		if (other.CompareTag ("Player")) {
			enemy.currentState.OnTriggerStay (other);
		}
	}
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Player")) {
			enemy.currentState.OnTriggerExit (other);
		}
	}
}
