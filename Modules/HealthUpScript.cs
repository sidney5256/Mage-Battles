using UnityEngine;
using System.Collections;

public class HealthUpScript : MonoBehaviour {

	public float healupAmt = 10f;
	public AudioClip sound;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			PlayerStats.stats.health += healupAmt;
			PlayerStats.stats.healthMax += healupAmt;
			AudioSource.PlayClipAtPoint (sound, transform.position, .5f);
			Destroy (gameObject);
		}
	}
}
