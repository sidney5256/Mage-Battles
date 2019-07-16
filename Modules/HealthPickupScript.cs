using UnityEngine;
using System.Collections;

public class HealthPickupScript : MonoBehaviour {

	public float healAmt = 25f;
	public AudioClip sound;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			PlayerStats.stats.health += healAmt;
			AudioSource.PlayClipAtPoint (sound, transform.position, .5f);
			Destroy (gameObject);
		}
	}
}
