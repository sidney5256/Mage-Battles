using UnityEngine;
using System.Collections;

public class AlertState : IEnemyStates{
	
	private readonly EnemyStatesAI enemy;
	private float searchTimer;
	private float suspicion = 0;

	public AlertState (EnemyStatesAI e){
		enemy = e;
	}

	public void UpdateState(){
		Search ();
	}

	public void OnTriggerEnter (Collider other){

	}
	public void OnTriggerStay (Collider other){
		suspicion += 1f * Time.deltaTime;
		if (suspicion > 2f) {
			ToEngageState ();
		}
	}
	public void OnTriggerExit (Collider other){
		
	}

	public void ToPatrolState(){
		enemy.currentState = enemy.patrolState;
		enemy.navMeshAgent.Resume ();
		enemy.symbol.text = " ";
		searchTimer = 0f;
		suspicion = 0f;
	}

	public void ToAlertState(){
		Debug.Log ("Can't transition to same state");
	}

	public void ToEngageState(){
		enemy.navMeshAgent.speed *= 2f;
		enemy.currentState = enemy.engageState;
		enemy.symbol.text = "!";
		searchTimer = 0f;
		suspicion = 0f;
		AudioSource.PlayClipAtPoint (enemy.seenSound, enemy.player.transform.position, .75f);
		enemy.engageTarget = enemy.player.transform;

		//gets array of nearby enemies and puts them in engageState as well
		Collider[] otherEnemies = Physics.OverlapSphere (enemy.transform.position, enemy.alertRadius.radius);
		for (int i = 0; i < otherEnemies.Length; i++) {
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
		searchTimer = 0f;
		suspicion = 0f;
		enemy.engageTarget = enemy.player.transform;

		//gets array of nearby enemies and puts them in engageState as well
		Collider[] otherEnemies = Physics.OverlapSphere (enemy.transform.position, enemy.alertRadius.radius);
		for (int i = 0; i < otherEnemies.Length; i++) {
			EnemyStatesAI AI = otherEnemies [i].gameObject.GetComponent<EnemyStatesAI> ();
			if (AI != null && AI.currentState != AI.engageState) { //checks if AI exists and its not already in engageState
				otherEnemies[i].gameObject.GetComponent<EnemyStatesAI> ().currentState.ToEngageStateNoSound ();
			}
		}
	}
		
	private void Search(){
		enemy.navMeshAgent.Stop ();
		searchTimer += Time.deltaTime;
		enemy.transform.Rotate (0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
		if (searchTimer >= enemy.searchingDuration)
			ToPatrolState ();
	}


}
