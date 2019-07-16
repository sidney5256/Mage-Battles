using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {

	public GameObject mobToSpawn;
	public GameObject refToPlayer;
	public float spawnRate;
	public bool spawnMobOnStart;
	private float nextSpawnTime;

	void Start () {
		if (!spawnMobOnStart) {
			nextSpawnTime = Time.time + spawnRate;
		}
	}

	void Update () {
		if (Time.time > nextSpawnTime) {
			GameObject mob = Instantiate (mobToSpawn, transform.position, transform.rotation) as GameObject;

			//Gives the mob a reference to the player at creation time
			if (mob.GetComponent<EnemyStatesAI>() != null) {
				EnemyStatesAI mobAI = mob.GetComponent<EnemyStatesAI> ();
				mobAI.player = refToPlayer;
				mobAI.engageTarget = refToPlayer.transform;
				mobAI.currentState.ToEngageStateNoSound ();
			}


			nextSpawnTime = Time.time + spawnRate;
		}
	}
}MobSp
