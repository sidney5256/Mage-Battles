using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyStates{

	private readonly EnemyStatesAI enemy;
	private int nextWayPoint;

	public PatrolState(EnemyStatesAI e){
		enemy = e;
	}

	public void UpdateState(){
		if (enemy.wayPoints.Length > 0) {
			Patrol ();
		}
	}

	public void OnTriggerEnter (Collider other){
		ToAlertState ();
	}
	public void OnTriggerStay (Collider other){

	}
	public void OnTriggerExit (Collider other){

	}

	public void ToPatrolState(){
		Debug.Log ("can't go to own state!");
	}

	public void ToAlertState(){
		AudioSource.PlayClipAtPoint (enemy.alertSound, enemy.player.transform.position, 1f);
		enemy.symbol.text = "?";
		enemy.currentState = enemy.alertState;
	}

	public void ToEngageState(){
		enemy.navMeshAgent.speed *= 2f;
		enemy.currentState = enemy.engageState;
		enemy.symbol.text = "!";
		AudioSource.PlayClipAtPoint (enemy.seenSound, enemy.player.transform.position, 0.75f);
		enemy.engageTarget = enemy.player.transform;

		//gets array of nearby enemies and puts them in engage state as well
		Collider[] otherEnemies = Physics.OverlapSphere (enemy.transform.position, enemy.alertRadius.radius);
		for (int i = 0; i < otherEnemies.Length; i++){
			EnemyStatesAI AI = otherEnemies [i].gameObject.GetComponent<EnemyStatesAI> ();
			if (AI != null && AI.currentState != AI.engageState) { //checks if AI exists and its not already in engageState
				otherEnemies[i].gameObject.GetComponent<EnemyStatesAI> ().currentState.ToEngageStateNoSound ();
			}
		}
	}
	public void ToEngageStateNoSound(){
		enemy.navMeshAgent.speed *= 2f;
		enemy.currentState = enemy.engageState;
		enemy.symbol.text = "!";
		enemy.engageTarget = enemy.player.transform;
		Collider[] otherEnemies = Physics.OverlapSphere (enemy.transform.position, enemy.alertRadius.radius);
		for (int i = 0; i < otherEnemies.Length; i++){
			EnemyStatesAI AI = otherEnemies [i].gameObject.GetComponent<EnemyStatesAI> ();
			if (AI != null && AI.currentState != AI.engageState) { //checks if AI exists and its not already in engageState
				otherEnemies[i].gameObject.GetComponent<EnemyStatesAI> ().currentState.ToEngageStateNoSound ();
			}
		}
	}


	private void Patrol () {
		if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance) {
			GoToNextPoint ();
		}
	}
	private void GoToNextPoint(){
		enemy.navMeshAgent.destination = enemy.wayPoints [nextWayPoint].position;
		nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
	}
}
