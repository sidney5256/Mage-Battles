using UnityEngine;
using System.Collections;

public class ManaPickup : MonoBehaviour {

	public float manaAmt = 75f;
	public AudioClip sound;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			PlayerStats.stats.mana += manaAmt;
			AudioSource.PlayClipAtPoint (sound, transform.position, .5f);
			Destroy (gameObject);
		}
	}
}
