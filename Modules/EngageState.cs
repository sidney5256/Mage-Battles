using UnityEngine;
using System.Collections;

public class EngageState : IEnemyStates{

	private readonly EnemyStatesAI enemy;
	private Vector3 direction;
	private Quaternion lookRotation;
	private bool isArcher;

	public EngageState (EnemyStatesAI e){
		enemy = e;
		isArcher = enemy.isArcher;
	}

	public void UpdateState(){
		Chase ();
		if (isArcher) {
			enemy.navMeshAgent.stoppingDistance = 50f;
		}
	}

	public void OnTriggerEnter (Collider other){
		if (other.GetComponent<EnemyStatesAI> () != null) {
			other.GetComponent<EnemyStatesAI> ().currentState.ToEngageState ();
		}
	}
	public void OnTriggerStay (Collider other){

	}
	public void OnTriggerExit (Collider other){

	}

	public void ToPatrolState(){

	}

	public void ToAlertState(){
		enemy.currentState = enemy.alertState;
	}

	public void ToEngageState(){
		Debug.Log ("Can't transition to same state");
	}
	public void ToEngageStateNoSound(){
		Debug.Log ("Can't transition to same state");
	}

	private void Chase(){
		enemy.navMeshAgent.destination = enemy.engageTarget.position;
		enemy.navMeshAgent.Resume ();
		if (Vector3.Distance (enemy.gameObject.transform.position, enemy.engageTarget.position) <= 30f || isArcher) { 
			direction = (enemy.engageTarget.position - enemy.gameObject.transform.position).normalized;
			lookRotation = Quaternion.LookRotation (direction);
			enemy.gameObject.transform.rotation = Quaternion.Slerp(enemy.gameObject.transform.rotation, lookRotation, Time.deltaTime * 5f);
		}
	}
}
