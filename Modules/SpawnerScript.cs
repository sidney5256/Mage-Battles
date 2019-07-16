using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour {

	public GameObject itemToSpawn;
	public float spawnRate;
	private float nextSpawnTime;
	private List<GameObject> spawnedItems = new List<GameObject>();
	private bool addedToSpawnTime;

	void Start () {
		GameObject item = Instantiate (itemToSpawn, transform.position, Quaternion.identity) as GameObject;
		spawnedItems.Add (item);
	}

	void Update () {
		if (spawnedItems [0] == null && !addedToSpawnTime) {
			nextSpawnTime = Time.time + spawnRate;
			addedToSpawnTime = true;
		}
		if (Time.time > nextSpawnTime && spawnedItems [0] == null) {
			spawnedItems.RemoveAt (0);
			GameObject item = Instantiate (itemToSpawn, transform.position, Quaternion.identity) as GameObject;
			spawnedItems.Add (item);
			addedToSpawnTime = false;
		}
	}
}
