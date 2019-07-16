using UnityEngine;
using System.Collections;

public class EnemyAttackBox : MonoBehaviour {

	public float damage;
	public float fireRate;
	public float nextFireTime;
	private Animator anim;

	void Start () {
		anim = GetComponentInParent<Animator> ();
	}

	void Update () {
	
	}
	void OnTriggerStay(Collider other){
		if (other.name == "Player" && Time.time > nextFireTime) {
			PlayerStats.stats.TakeDamage (damage);
			nextFireTime = Time.time + fireRate;
			anim.Play ("SoldierEngage", -1, 0f);
		}
	}
}
