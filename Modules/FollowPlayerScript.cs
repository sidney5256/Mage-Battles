using UnityEngine;
using System.Collections;

public class FollowPlayerScript: MonoBehaviour {

	public Transform goal;
	private Vector3 startingPos;
	public float rotationSpeed = 1f;
	public float lookDistance;
	private Vector3 direction;
	private Quaternion lookRotation;
	private UnityEngine.AI.NavMeshAgent agent;

	void Start(){
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		startingPos = transform.position;
	}

	void Update() {
		if (Vector3.Distance (transform.position, goal.position) < 50f) {
			agent.destination = goal.position;
		} else {
			agent.destination = startingPos;
		}

		/*
		  The below if statement makes enemy slowly turn to face player. Right now, because the player is a
		  nav mesh obstable, the enemy will steer away when it gets close to player (it thinks its an obstacle).
		  So the if statement forces it to look at the player. Can't use transform that LookAt(player), it causes
		  a sudden jerk at the player. Slerp makes it gradual.
		*/

		if (Vector3.Distance (transform.position, goal.position) <= lookDistance) { 
			direction = (goal.position - transform.position).normalized;
			lookRotation = Quaternion.LookRotation (direction);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
		}
	}
}
