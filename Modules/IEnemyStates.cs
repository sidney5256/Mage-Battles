using UnityEngine;
using System.Collections;

public interface IEnemyStates{

	void UpdateState();

	//the "Alert Radius" game object trigger will call the trigger funtions below
	void OnTriggerEnter (Collider other);
	void OnTriggerStay (Collider other);
	void OnTriggerExit (Collider other);

	void ToPatrolState();
	void ToAlertState();
	void ToEngageState();
	void ToEngageStateNoSound();

}
