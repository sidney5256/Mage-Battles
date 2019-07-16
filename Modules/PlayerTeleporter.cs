using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerTeleporter : MonoBehaviour {

	public Transform destination;
	public GameObject activateThis;
	public GameObject andMaybeThisToo;
	public GameObject deactivateThis;
	public AudioClip sound;
	public bool healMana = true;

	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {

			other.GetComponent<FirstPersonController> ().forceRotationFlag = true;
			other.transform.position = destination.position;
			other.transform.rotation = destination.rotation;

			activateThis.SetActive (true);

			if (andMaybeThisToo != null) {
				andMaybeThisToo.SetActive (true);
			}

			if (deactivateThis != null) {
				deactivateThis.SetActive (false);
			}
			if (healMana) {
				PlayerStats.stats.mana = PlayerStats.stats.manaMax;
			}

			AudioSource.PlayClipAtPoint (sound, destination.transform.position);
		}
	}
}
