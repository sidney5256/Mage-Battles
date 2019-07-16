using UnityEngine;
using System.Collections;

public class EnemyAggroAI : MonoBehaviour {

	public float aggroDistance;
	public MonoBehaviour AIscript;
	private GameObject player;

	void Start () {
		AIscript.enabled = false;
		player = GameObject.Find ("Player");
	}

	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) < aggroDistance && !AIscript.enabled) {
			AIscript.enabled = true;
		} else if (Vector3.Distance (transform.position, player.transform.position) >= aggroDistance && AIscript.enabled) {
			AIscript.enabled = false;
		}
	}
}
