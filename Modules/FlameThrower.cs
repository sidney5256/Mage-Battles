using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlameThrower : MonoBehaviour {

	private EnemyStats enemy;
	private List<GameObject> enemiesInTrigger;
	private float fireRate = .25f;
	private float nextFireTime;
	public bool isOn;

	void Start(){
		enemiesInTrigger = new List<GameObject>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<EnemyStats> () != null) {
			enemiesInTrigger.Add (other.gameObject);
		}
	}
	void OnTriggerExit(Collider other){
		if (enemiesInTrigger != null && enemiesInTrigger.Contains (other.gameObject)) {
			enemiesInTrigger.Remove (other.gameObject);
		}
	}
	void Update(){
		if (enemiesInTrigger != null && isOn) {
			for (int i = 0; i < enemiesInTrigger.Count; i++) {
				if (enemiesInTrigger [i] == null) {
					enemiesInTrigger.Remove (enemiesInTrigger[i]);
				}
				if (Time.time > nextFireTime) {
					enemy = enemiesInTrigger [i].GetComponent<EnemyStats> ();
					enemy.TakeDamage (PlayerStats.stats.fireSpell.damage / 4);
				}
			}
		}
		if (Time.time > nextFireTime) {
			nextFireTime = Time.time + fireRate;
		}
	}
}
