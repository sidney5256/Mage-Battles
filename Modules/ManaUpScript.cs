using UnityEngine;
using System.Collections;

public class ManaUpScript : MonoBehaviour {

	public float manaAmt = 10f;
	public AudioClip sound;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			PlayerStats.stats.manaMax += manaAmt;
			PlayerStats.stats.manaRegen += manaAmt / 20f;
			AudioSource.PlayClipAtPoint (sound, transform.position, .5f);
			Destroy (gameObject);
		}
	}
}
