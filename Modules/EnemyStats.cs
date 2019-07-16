using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public float maxHealth;
	public float health;
	[HideInInspector] public float speed;
	[HideInInspector] public bool isSlowed;
	[HideInInspector] public UnityEngine.AI.NavMeshAgent nav;
	[HideInInspector] public EnemyStats stats;

	public float slowTime;
	public float originalSpeed;

	void Start () {
		isSlowed = false;
		if (GetComponent<UnityEngine.AI.NavMeshAgent> () != null) {
			nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
			originalSpeed = nav.speed;
		}
	}

	void Update () {
		//if its been slowed for a certain time, un-slow itself
		if (isSlowed && Time.time > slowTime) {
			isSlowed = false;
			nav.speed = originalSpeed;
		}
		Mathf.Clamp (health, 0f, maxHealth);

	}
	public void TakeDamage(float dmg){
		health -= dmg;
		if (gameObject.GetComponent<EnemyStatesAI> () != null) {
			gameObject.GetComponent<EnemyStatesAI> ().currentState.ToEngageState ();
		}
	}
}
