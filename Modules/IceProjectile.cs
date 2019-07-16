using UnityEngine;
using System.Collections;

public class IceProjectile : MonoBehaviour {

	private Rigidbody rb;
	public GameObject explosion;
	private EnemyStats enemyStats;
	public AudioClip sound;
	public GameObject slowEffect;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * 25f;
		AudioSource.PlayClipAtPoint (sound, transform.position);
	}

	// Update is called once per frame
	void Update () {

		//if the projectile would hit something not an enemy, it destroys early before it collides.
		//this is here because for some reason it can collide with a shield, AND the enemy behind the shield.
		//so if the projectile destroys itself early, then this won't happen.
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 1f)) {
			if (hit.collider.GetComponent<EnemyStats> () == null) {
				explosion.transform.SetParent (null);
				explosion.SetActive (true);
				Destroy (gameObject);
			}
		}
	}
	void OnCollisionEnter(Collision other){
		enemyStats = other.collider.GetComponent<EnemyStats> ();
		if (!other.collider.CompareTag ("Player")) {
			if (enemyStats != null) {
				
				//deals damage to enemy
				enemyStats.TakeDamage (PlayerStats.stats.iceSpell.damage);

				//add ice particle affect around affected enemy
				GameObject clone = Instantiate (slowEffect, other.collider.transform.position, Quaternion.identity) as GameObject;
				clone.transform.SetParent (other.collider.transform);

				//add to slow duration
				enemyStats.slowTime = Time.time + 3f;
			}
			if (other.collider.GetComponent<UnityEngine.AI.NavMeshAgent>() != null && !enemyStats.isSlowed) {
				SlowTarget (other);		
			}

			explosion.transform.SetParent (null);
			explosion.SetActive (true);
			Destroy (gameObject);
		}
	}

	void SlowTarget(Collision other){ //refereces the EnemyStats script to know when to stop being slowed
		UnityEngine.AI.NavMeshAgent enemyNav = other.collider.GetComponent<UnityEngine.AI.NavMeshAgent> ();
		enemyStats.isSlowed = true;		
		enemyStats.originalSpeed = enemyNav.speed;
		enemyNav.speed *= .5f;
	}
}
